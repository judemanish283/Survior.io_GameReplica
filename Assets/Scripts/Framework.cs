using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework
{
    [Serializable]
    public class PlayerData
    {
        public int playerHealth = 100;
        public int playerScore = 000;
        public int playerCoins = 000;

        public int UpdateHealth(int val) => playerHealth += val;
        public int UpdateScore(int val) => playerScore += val;
        public int UpdateCoins(int val) => playerCoins += val;

    }
}
