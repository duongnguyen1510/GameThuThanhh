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
        
        public List<TitleMapHA> ListPath = new List<TitleMapHA>();
        public float speed = 1;
        public void SetupData(List<TitleMapHA> ListPath)
        {
            this.ListPath = new List<TitleMapHA>(ListPath);
        }
        
        public void Update()
        {
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
    }
}
