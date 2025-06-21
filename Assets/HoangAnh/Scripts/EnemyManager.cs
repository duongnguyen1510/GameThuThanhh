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

        private List<EnemyHA> listEnemy = new List<EnemyHA>();
        public List<EnemyHA> ListEnemy
        {
            get => listEnemy;
        }
        public int CountEnemyInWare { get; private set; }
        public int CountEnemyCurrent { get; private set; }
        
        private void Awake()
        {
            Ins = this;
        }

        public void Update()
        {
            if (GameManager.StateGameCurrent != EStateGame.PLAY)
            {
                return;
            }
        }

        public void SpawmWare(int ware)
        {
            int numberEnemySpawn = NumberEnemyInOneWare + ware * 3;
            StartCoroutine(ISpawnWare(numberEnemySpawn));
        }

        IEnumerator ISpawnWare(int numberSpawn)
        {
            CountEnemyInWare = numberSpawn;
            CountEnemyCurrent = numberSpawn;
            for (int i = 0; i < numberSpawn; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(2f);
            }
        }

        private void SpawnEnemy()
        {
            EnemyHA enemySpawn = Instantiate(enemyPrefab, transpawnEnemy);
            listEnemy.Add(enemySpawn);
            enemySpawn.SetupData(SpawnMapHa.ListPath);
            Vector3 posSpawn = SpawnMapHa.ListPath[0].transform.position;
            posSpawn.x -= 1f;
            enemySpawn.transform.position = posSpawn;
        }

        public void EnemyDeath()
        {
            CountEnemyCurrent--;
        }
    }
}
