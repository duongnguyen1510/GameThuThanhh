using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoangAnh
{
    public class TankVisual : MonoBehaviour
    {
        [Space, Header("Component")]
        [SerializeField] private Transform[] _transPointsSpawn;
        [SerializeField] private Transform _transVisualShoot;

        public Transform[] TransPointsSpawn
        {
            get => _transPointsSpawn;
        }

        public Transform TransVisualShoot
        {
            get => _transVisualShoot;
        }
    }
}
