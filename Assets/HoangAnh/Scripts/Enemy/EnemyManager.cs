using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoangAnh
{
    public class EnemyManager : MonoBehaviour
    {
        public const int NumberEnemyInOneWare = 5;
        public static EnemyManager Ins;

        [Space, Header("Enemy")] 
        [SerializeField] private EnemyHA enemyPrefab;
        [SerializeField] private Transform transpawnEnemy;
        [SerializeField] private SpawnMapHA SpawnMapHa;
        
        private void Awake()
        {
            Ins = this;
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SpawmWare(2);
            }
        }

        public void SpawmWare(int ware)
        {
            int numberEnemySpawn = NumberEnemyInOneWare + ware * 3;
            StartCoroutine(ISpawnWare(numberEnemySpawn));
        }

        IEnumerator ISpawnWare(int numberSpawn)
        {
            for (int i = 0; i < numberSpawn; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(1f);
            }
        }

        private void SpawnEnemy()
        {
            EnemyHA enemySpawn = Instantiate(enemyPrefab, transpawnEnemy);
            enemySpawn.SetupData(SpawnMapHa.ListPath);
            Vector3 posSpawn = SpawnMapHa.ListPath[0].transform.position;
            posSpawn.x -= 1f;
            enemySpawn.transform.position = posSpawn;
        }
    }
}
