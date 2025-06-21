using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoangAnh
{
    public enum EStateGame
    {
        NONE,
        PLAY,
        PAUSE
    }
    public class GameManager : MonoBehaviour
    {
        public static EStateGame StateGameCurrent { get; private set; }

        private void Awake()
        {
            StateGameCurrent = EStateGame.NONE;
        }

        public static void SetStateGame(EStateGame state)
        {
            StateGameCurrent = state;
        }
    }
}
