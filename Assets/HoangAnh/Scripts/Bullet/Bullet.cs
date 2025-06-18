using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoangAnh
{
    public class Bullet : MonoBehaviour
    {
        private EnemyHA enemyTarget;
        private DataBullet dataBullet;
        
        public void SetupData(DataBullet dataBullet, EnemyHA enemyTarget)
        {
            this.dataBullet = dataBullet;
            this.enemyTarget = enemyTarget;
        }

        public void Update()
        {
            if (enemyTarget != null)
            {
                Vector3 posEnemy = enemyTarget.TransPositionTarget.position;
                Vector3 posCurrent = transform.position;
                float distance = Vector3.Distance(posCurrent, posEnemy);
                if (distance > 0.05f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, posEnemy, dataBullet.speed * Time.deltaTime);
                }
                else
                {
                    enemyTarget.TakeDamage(dataBullet.dame);
                    Destroy(gameObject);
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
