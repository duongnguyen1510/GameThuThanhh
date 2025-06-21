using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace HoangAnh
{
    public enum EStateTank
    {
        PAUSE,
        PLAY
    }
    public class Tank : MonoBehaviour
    {
        [Space, Header("Properties")] 
        [SerializeField] private int levelCurrent;

        [FormerlySerializedAs("_TransSpawnVisual")]
        [Space, Header("Component")] 
        [SerializeField] private Transform _transSpawnVisual;
        [SerializeField] private Transform _transRangeAtt;
        [SerializeField] private TankShoot _tankShoot;
        
        public int LevelCurrent
        {
            get => levelCurrent;
        }

        private DataManager dataManager;
        private DataTankSO dataTankSO;
        private DataTankContainerSO dataTankContainerSO;
        private TankVisual _tankVisual;
        public EStateTank StateTankCurrent { get; private set; }
        public TankVisual TankVisual
        {
            get => _tankVisual;
        }
        
        public void Initialized()
        {
            if (_tankShoot == null)
            {
                _tankShoot = transform.GetComponent<TankShoot>();
            }
            if (dataManager == null)
            {
                dataManager = DataManager.Ins;
            }
            StateTankCurrent = EStateTank.PAUSE;
            ResetData();
        }

        public void ActiveTank()
        {
            StateTankCurrent = EStateTank.PLAY;
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
                dataTankContainerSO = dataManager.DataTankContainerSO;
            }
            if (dataTankContainerSO.MaxLevelTank < levelCurrent)
            {
                levelCurrent = dataTankContainerSO.MaxLevelTank;
            }
            dataTankSO = dataTankContainerSO.GetDataTankSO(levelCurrent);
            _tankShoot.Initialized(dataTankSO.Data, this);
            if (_tankVisual != null)
            {
                Destroy(_tankVisual.gameObject);
            }
            _tankVisual = Instantiate(dataTankSO.Data.visualPrefab, _transSpawnVisual);
        }

        public void EnableRangeAtt(bool enable)
        {
            _transRangeAtt.gameObject.SetActive(enable);
        }

        public void SpawnBullet(EnemyHA enemy)
        {
            Transform[] pointsSpawn = TankVisual.TransPointsSpawn;
            foreach (var pointSpawn in pointsSpawn)
            {
                Bullet bullet = Instantiate(dataManager.BulletPrefab);
                bullet.SetupData(dataTankSO.Data.dataBullet, enemy);
                bullet.transform.position = pointSpawn.position;
                Vector3 targetPosition = enemy.TransPositionTarget.position;
                targetPosition.y = pointSpawn.position.y;
                Vector3 dirToEnemy = (targetPosition - pointSpawn.position).normalized;
                _tankVisual.TransVisualShoot.rotation = Quaternion.LookRotation(dirToEnemy);
            }
        }
    }
}