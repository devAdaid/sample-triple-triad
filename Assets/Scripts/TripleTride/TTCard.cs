using UnityEngine;

namespace Ahyeong.TripleTride
{
    public enum Direction
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

        public int GetRankOf(Direction direction)
        {
            switch(direction)
            {
                case Direction.Up:
                    return RankUp;
                case Direction.Right:
                    return RankRight;
                case Direction.Down:
                    return RankDown;
                case Direction.Left:
                    return RankLeft;
            }
            return -1;
        }

        public int GetOppositeRankOf(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return RankDown;
                case Direction.Right:
                    return RankLeft;
                case Direction.Down:
                    return RankUp;
                case Direction.Left:
                    return RankRight;
            }
            return -1;
        }
    }
}