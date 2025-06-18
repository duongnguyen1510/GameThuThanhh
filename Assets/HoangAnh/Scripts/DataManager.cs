using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoangAnh
{
    public class DataManager : MonoBehaviour
    {
        public static DataManager Ins;

        [Space, Header("Data Tanks")] 
        [SerializeField] DataTankContainerSO _dataTankContainerSO;
        [SerializeField] Bullet _bulletPrefab;

        public DataTankContainerSO DataTankContainerSO
        {
            get => _dataTankContainerSO;
        }

        public Bullet BulletPrefab
        {
            get => _bulletPrefab;
        }
        
        private void Awake()
        {
            Ins = this;
        }
    }
}
