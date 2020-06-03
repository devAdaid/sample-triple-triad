using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ahyeong.TripleTride
{
    public class TTRuleContext
    {
        public delegate int Compared(ref int result);
        
        public System.Comparison<int> rankComaparison = TTRule.Compare;
        public Compared afterCompareCallback;

        public void ApplyRuleOnMove(TTBoard board, int movedPlayerNumber, int i, int j)
        {
            TTCard movedCard = board.slots[i, j];

            foreach (EDirection direction in System.Enum.GetValues(typeof(EDirection)))
            {
                TTCard adjacentCard = board.GetCardAt(i, j, direction);
                if (adjacentCard != null && adjacentCard.ownPlayer != movedPlayerNumber)
                {
                    bool canTurnCard = CompareRank(movedCard.GetRankOf(direction), adjacentCard.GetOppositeRankOf(direction)) > 0;
                    if(canTurnCard)
                    {
                        adjacentCard.ownPlayer = movedPlayerNumber;
                    }
                }
            }
        }

        public int CompareRank(int value1, int value2)
        {
            int result = rankComaparison(value1, value2);
            if(afterCompareCallback != null)
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

        public void ApplyRule(TTRule rule)
        {
            rule.ApplyRuleAt(this);
        }
    }
}