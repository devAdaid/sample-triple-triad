﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ECardType
{
    None,
    Primal,
    Dawn,
    Empire,
    Beastmen
}

namespace Ahyeong.TripleTride
{
    [CreateAssetMenu]
    public class TTCardData : ScriptableObject
    {
        public string cardName;
        public Sprite cardSprite;
        public ECardType type;
        public int rankUp;
        public int rankRight;
        public int rankDown;
        public int rankLeft;
    }
}