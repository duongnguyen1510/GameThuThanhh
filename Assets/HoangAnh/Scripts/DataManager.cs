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

        public DataTankContainerSO DataTankContainerSO
        {
            get => _dataTankContainerSO;
        }
        
        private void Awake()
        {
            Ins = this;
        }
    }
}
