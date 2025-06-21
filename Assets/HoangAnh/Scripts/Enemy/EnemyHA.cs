using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoangAnh
{
    public class EnemyHA : MonoBehaviour
    {
        [Space,Header("Animation")]
        [SerializeField] Animator _animator;
        [SerializeField] private Renderer _renderer;
        [SerializeField] Transform _transPositionTarget;
        [SerializeField] private Color _colorHit;
        [SerializeField] private Color _colorDefault;
        
        public Transform TransPositionTarget
        {
            get => _transPositionTarget;
        }
        private Material materialCurrent;
        private Coroutine coroutine;
        private List<TitleMapHA> ListPath = new List<TitleMapHA>();
        private float speed = 0.5f;
        private float healthCurrent = 30;
        
        public bool isDie;
        
        public void SetupData(List<TitleMapHA> ListPath)
        {
            this.ListPath = new List<TitleMapHA>(ListPath);
            materialCurrent = _renderer.material;
            _animator.SetBool("isDie", false);
            _animator.SetBool("isRun", false);
            isDie = false;
        }
        
        public void Update()
        {
            if (GameManager.StateGameCurrent != EStateGame.PLAY)
            {
                return;
            }
            if (isDie)
            {
                return;
            }
            if (ListPath.Count > 0)
            {
                TitleMapHA titleTarget = ListPath[0];
                Vector3 posTarget = titleTarget.transform.position;
                if (ListPath.Count == 1)
                {
                    posTarget.x += 2f;
                }
                Vector3 positionTarget = new Vector3(posTarget.x, transform.position.y, posTarget.z);
                float distance = Vector3.Distance(transform.position, positionTarget);
                if (distance > 0.05f)
                {
                    Vector3 direction = (positionTarget - transform.position).normalized;
                    if (direction != Vector3.zero) 
                    {
                        Quaternion lookRotation = Quaternion.LookRotation(direction);
                        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 20f); 
                    }
                    _animator.SetBool("isRun", true);
                    transform.position = Vector3.MoveTowards(transform.position, positionTarget, speed * Time.deltaTime);
                }
                else
                {
                    ListPath.RemoveAt(0);
                    if (ListPath.Count <= 0)
                    {
                        _animator.SetBool("isRun", false);
                        Debug.Log("Thua");
                    }
                }
            }
        }
        
        public void TakeDamage(float damage)
        {
            if (healthCurrent > 0)
            {
                healthCurrent -= damage;
                if (coroutine != null)
                {
                    StopCoroutine(coroutine);
                }
                coroutine = StartCoroutine(ChangeColor(materialCurrent, _colorDefault, _colorHit, 0.1f, 0.1f));
                if (healthCurrent <= 0)
                {
                    isDie = true;
                    _animator.SetBool("isDie", true);
                    float timeDeath = GetTimePlayAnimation("Death");
                    timeDeath += 0.1f; 
                    StartCoroutine(IWaitDeath(timeDeath));
                }
            }
        }

        private IEnumerator IWaitDeath(float timeDeath)
        {
            yield return new WaitForSeconds(timeDeath);
            Death();
        }
        
        private float GetTimePlayAnimation(string animName)
        {
            RuntimeAnimatorController controller = _animator.runtimeAnimatorController;
            float timeDuration = 0;
            foreach (var clip in controller.animationClips)
            {
                if (clip.name == animName)
                {
                    timeDuration = clip.length;
                    break;
                }
            }
            return timeDuration;
        }

        private void Death()
        {
            EnemyManager.Ins.EnemyDeath();
            EnemyManager.Ins.ListEnemy.Remove(this);
            Destroy(gameObject);
        }
        
        public IEnumerator ChangeColor(Material material, Color fromColor, Color toColor, float duration, float timeWait)
        {
            yield return StartCoroutine(LerpColor(material, fromColor, toColor, duration));
            yield return new WaitForSeconds(timeWait);
            StartCoroutine(LerpColor(material, toColor, fromColor, duration));
        }
        private IEnumerator LerpColor(Material material, Color fromColor, Color toColor, float duration)
        {
            float time = 0f;
            while (time < duration)
            {
                time += Time.deltaTime;
                material.color = Color.Lerp(fromColor, toColor, time / duration);
                yield return null;
            }
            material.color = toColor;
        }
    }
}
