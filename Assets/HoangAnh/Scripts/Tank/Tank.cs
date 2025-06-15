using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace HoangAnh
{
    public class Tank : MonoBehaviour
    {
        [Space, Header("Properties")] 
        [SerializeField] private int levelCurrent;

        [FormerlySerializedAs("_TransSpawnVisual")]
        [Space, Header("Component")] 
        [SerializeField] private Transform _transSpawnVisual;
        [SerializeField] private Transform _transRangeAtt;

        public int LevelCurrent
        {
            get => levelCurrent;
        }

        private DataTankSO dataTankSO;
        private DataTankContainerSO dataTankContainerSO;
        private GameObject objVisual;

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
            if (dataTankContainerSO == null)
            {
                dataTankContainerSO = DataManager.Ins.DataTankContainerSO;
            }
            if (dataTankContainerSO.MaxLevelTank < levelCurrent)
            {
                levelCurrent = dataTankContainerSO.MaxLevelTank;
            }
            dataTankSO = dataTankContainerSO.GetDataTankSO(levelCurrent);
            if (objVisual != null)
            {
                Destroy(objVisual.gameObject);
            }
            objVisual = Instantiate(dataTankSO.Data.visualPrefab, _transSpawnVisual);
        }

        public void EnableRangeAtt(bool enable)
        {
            _transRangeAtt.gameObject.SetActive(enable);
        }
    }
}