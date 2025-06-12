using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoangAnh
{
    public class Tank : MonoBehaviour
    {
        [Space, Header("Visual")]
        [SerializeField] private GameObject[] visualsTanks;

        public int levelCurrent = 1;

        public void Initialized()
        {
            ResetData();
        }

        private void ResetData()
        {
            levelCurrent = 1;
            UpdateVisual();
        }

        public void UpLevel()
        {
            levelCurrent++;
            UpdateVisual();
        }

        private void UpdateVisual()
        {
            for(int i = 0; i < visualsTanks.Length; i++)
            {
                if (i + 1 == levelCurrent)
                {
                    visualsTanks[i].SetActive(true);
                }
                else
                {
                    visualsTanks[i].SetActive(false);
                }
            }
        }
    }
}
