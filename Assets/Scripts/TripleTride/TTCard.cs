using UnityEngine;

namespace Ahyeong.TripleTride
{
    public enum EDirection
    {
        Up,
        Right,
        Down,
        Left
    }

    [System.Serializable]
    public class TTCard
    {
        public const int MinPower = 1;
        public const int MaxPower = 10;
        
        public int RankUp => Mathf.Clamp(cardData.rankUp + rankDifference, MinPower, MaxPower);
        public int RankRight => Mathf.Clamp(cardData.rankRight + rankDifference, MinPower, MaxPower);
        public int RankDown => Mathf.Clamp(cardData.rankDown + rankDifference, MinPower, MaxPower);
        public int RankLeft => Mathf.Clamp(cardData.rankLeft + rankDifference, MinPower, MaxPower);

        public TTCardData cardData = null;
        public int rankDifference = 0;
        public int belongPlayerId = 0;

        public TTCard(TTCardData data, int playerId)
        {
            cardData = data;
            rankDifference = 0;
            belongPlayerId = playerId;
        }

        public int GetRankOf(EDirection direction)
        {
            switch(direction)
            {
                case EDirection.Up:
                    return RankUp;
                case EDirection.Right:
                    return RankRight;
                case EDirection.Down:
                    return RankDown;
                case EDirection.Left:
                    return RankLeft;
            }
            return -1;
        }

        public int GetOppositeRankOf(EDirection direction)
        {
            switch (direction)
            {
                case EDirection.Up:
                    return RankDown;
                case EDirection.Right:
                    return RankLeft;
                case EDirection.Down:
                    return RankUp;
                case EDirection.Left:
                    return RankRight;
            }
            return -1;
        }
    }
}