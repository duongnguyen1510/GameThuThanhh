using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoangAnh
{
    [CreateAssetMenu(menuName = "Data/DataTankSO", fileName = "DataTankSO")]
    public class DataTankSO : ScriptableObject
    {
        [SerializeField] private DataTank _data;
        public DataTank Data
        {
            get => _data;
        }
    }
    
    [System.Serializable]
    public class DataTank
    {
        public int idTank;
        public GameObject visualPrefab;
        public float speed;
        public float dame;
        public float rangeAtt;
    }
}