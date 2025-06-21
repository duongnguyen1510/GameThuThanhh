using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HoangAnh
{
    public class UIStart : MonoBehaviour
    {
        [SerializeField] private Button _btnStartGame;
        [SerializeField] private GameObject _uiInGame;
        private void Awake()
        {
            _btnStartGame.onClick.AddListener(OnStartGame);
        }

        private void OnStartGame()
        {
            gameObject.SetActive(false);
            _uiInGame.gameObject.SetActive(true);
            GameManager.SetStateGame(EStateGame.PLAY);
            EnemyManager.Ins.SpawmWare(1);
        }
    }
}
