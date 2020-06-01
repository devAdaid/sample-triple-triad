using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ahyeong.TripleTride
{
    public class TTCard
    {
        public const int MinPower = 1;
        public const int MaxPower = 10;

        public string CardName => cardData.cardName;
        public Sprite CardSprite => cardData.cardSprite;
        public int RankUp => Mathf.Clamp(cardData.rankUp + rankDifference, MinPower, MaxPower);
        public int RankRight => Mathf.Clamp(cardData.rankRight + rankDifference, MinPower, MaxPower);
        public int RankDown => Mathf.Clamp(cardData.rankDown + rankDifference, MinPower, MaxPower);
        public int RankLeft => Mathf.Clamp(cardData.rankLeft + rankDifference, MinPower, MaxPower);

        public TTCardData cardData = null;
        public int rankDifference = 0;
        public int ownPlayer = 0;

        public TTCard(TTCardData data, int player)
        {
            cardData = data;
            rankDifference = 0;
            ownPlayer = player;
        }
    }
}