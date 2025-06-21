using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HoangAnh
{
    public class UIEnemyCountInWare : MonoBehaviour
    {
        [SerializeField] private Text txt_Count;

        private EnemyManager enemyManager;
        
        public void Update()
        {
            if (enemyManager == null)
            {
                enemyManager = EnemyManager.Ins;
            }

            if (enemyManager.ListEnemy != null)
            {
                txt_Count.text = "Enemy: " + enemyManager.CountEnemyCurrent + "/" + enemyManager.CountEnemyInWare;
            }
        }
    }
}
