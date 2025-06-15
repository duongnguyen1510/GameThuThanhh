using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoangAnh
{
    [CreateAssetMenu(menuName = "Data/DataTankContainerSO", fileName = "DataTankContainerSO")]
    public class DataTankContainerSO : ScriptableObject
    {
        [SerializeField] private int _maxLevelTank;
        [SerializeField] private List<DataTankSO> _listDataTankSO;
        public List<DataTankSO> ListDataTankSO
        {
            get => _listDataTankSO;
        }

        public int MaxLevelTank
        {
            get => _maxLevelTank;
        }

        public DataTankSO GetDataTankSO(int id)
        {
            foreach (var item in ListDataTankSO)
            {
                if (item.Data.idTank == id)
                {
                    return item;
                }
            }
            return null;
        }
    }
}