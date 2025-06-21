using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoangAnh
{
    public class TankShoot : MonoBehaviour
    {
        [Space, Header("Spawn")]
        [SerializeField] private Transform _spawnPoint;

        private EnemyManager enemyManager;
        private Tank tank;
        private DataTank Data;
        private float rangeAtt => Data.rangeAtt / 2;
        private float speedAtt => Data.speed;
        private float timeDelayShoot;
            
        public void Initialized(DataTank Data, Tank tank)
        {
            this.Data = Data;
            this.tank = tank;
        }
        
        private void Update()
        {
            if (GameManager.StateGameCurrent != EStateGame.PLAY || tank.StateTankCurrent != EStateTank.PLAY)
            {
                return;
            }
            if (enemyManager == null)
            {
                enemyManager = EnemyManager.Ins;
            }
            if (timeDelayShoot <= 0)
            {
                List<EnemyHA> listEnemyCurrent = enemyManager.ListEnemy;
                if (listEnemyCurrent.Count > 0)
                {
                    foreach (EnemyHA enemy in listEnemyCurrent)
                    {
                        if (enemy.isDie)
                        {
                            continue;
                        }
                        Vector3 posEnemy = enemy.transform.position;
                        Vector3 posCurrent = transform.position;
                        float distance = Vector3.Distance(posCurrent, posEnemy);
                        if (distance <= rangeAtt)
                        {
                            tank.SpawnBullet(enemy);
                            timeDelayShoot = speedAtt;
                            break;
                        }
                    }
                }
            }

            if (timeDelayShoot >= 0)
            {
                timeDelayShoot -= Time.deltaTime;
            }
            else
            {
                timeDelayShoot = 0;
            }
        }
    }
}
