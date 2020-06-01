using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ahyeong.TripleTride
{

    public class TTRuleContext
    {
        public delegate int RankComapareFunction(int value1, int value2, System.Comparison<int> aceComparison);
        public delegate int ReverseFunction(int result);
        
        public System.Comparison<int> rankComapareFunction = TTRule.Compare;
        public bool reverseRankComparison = false;

        public int CompareRank(int value1, int value2)
        {
            int result = rankComapareFunction(value1, value2);
            if(reverseRankComparison)
            {
                result = -result;
            }
            return result;
        }

        public void ApplyDefaultRules()
        {
            rankComapareFunction = TTRule.Compare;
            reverseRankComparison = false;
        }

        public void ApplyRule(TTRule rule)
        {
            rule.ApplyRuleAt(this);
        }
    }
}