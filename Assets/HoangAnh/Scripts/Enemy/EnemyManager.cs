using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoangAnh
{
    public class EnemyManager : MonoBehaviour
    {
        public static EnemyManager Ins;

        [Space, Header("Enemy")] 
        [SerializeField] private EnemyHA enemyPrefab;
        [SerializeField] private Transform transpawnEnemy;
        [SerializeField] private SpawnMapHA SpawnMapHa;
        
        private void Awake()
        {
            Ins = this;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                EnemyHA enemy = SpawnEnemy();
                enemy.SetupData(SpawnMapHa.ListPath);
                enemy.transform.position = SpawnMapHa.ListPath[0].transform.position;
            }
        }

        private EnemyHA SpawnEnemy()
        {
            EnemyHA enemySpawn = Instantiate(enemyPrefab, transpawnEnemy);
            return enemySpawn;
        }
    }
}
