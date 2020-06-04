namespace Ahyeong.TripleTride
{
    public class TTRuleContext
    {
        public delegate int Compared(ref int result);
        
        public System.Comparison<int> rankComaparison = TTRule.Compare;
        public Compared afterCompareCallback;

        public void ApplyRuleOnMove(TTBoard board, int movedPlayerId, int index_i, int index_j)
        {
            TTCard movedCard = board.GetCardAt(index_i, index_j);

            foreach (Direction direction in System.Enum.GetValues(typeof(Direction)))
            {
                TTCard adjacentCard = board.GetCardAt(index_i, index_j, direction);
                if (adjacentCard != null && (adjacentCard.belongPlayerId != movedPlayerId) )
                {
                    int movedCardRank = movedCard.GetRankOf(direction);
                    int adjacentCardRank = adjacentCard.GetOppositeRankOf(direction);
                    bool canTurnCard = CompareRank(movedCardRank, adjacentCardRank) > 0;
                    if (canTurnCard)
                    {
                        adjacentCard.belongPlayerId = movedPlayerId;
                    }
                }
            }
        }

        public int CompareRank(int value1, int value2)
        {
            int result = rankComaparison(value1, value2);
            if (afterCompareCallback != null)
            {
                result = afterCompareCallback(ref result);
            }
            return result;
        }

        public void ResetRules()
        {
            rankComaparison = TTRule.Compare;
            afterCompareCallback = null;
        }
    }
}