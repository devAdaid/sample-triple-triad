using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ahyeong.TripleTride
{
    public abstract class TTRule
    {
        public bool canApplyCondition;
        public const int ACE = 10;

        public abstract void ApplyRuleAt(TTRuleContext ruleContext);
        
        public static int Compare(int value1, int value2)
        {
            return value1 - value2;
        }

        public static int CompareAceFalling(int value1, int value2)
        {
            int result = Compare(value1, value2);

            if (value1 == ACE && value2 == 1)
            {
                result = -1;
            }
            else if (value2 == ACE && value1 == 1)
            {
                result = 1;
            }

            return result;
        }
    }

    #region Card Reveal Rules

    // 모두 공개
    public class TTAllOpenRule : TTRule
    {
        public override void ApplyRuleAt(TTRuleContext ruleContext)
        {

        }
    }

    // 3장 공개
    public class TTThreeOpenRule : TTRule
    {
        public override void ApplyRuleAt(TTRuleContext ruleContext)
        {

        }
    }

    #endregion

    #region Card Selection Rules

    // 무작위 패
    public class TTRandomRule : TTRule
    {
        public override void ApplyRuleAt(TTRuleContext ruleContext)
        {

        }
    }

    // 순서대로
    public class TTOrderRule : TTRule
    {
        public override void ApplyRuleAt(TTRuleContext ruleContext)
        {

        }
    }

    // 무작위 순서
    public class TTChaosRule : TTRule
    {
        public override void ApplyRuleAt(TTRuleContext ruleContext)
        {

        }
    }

    // 카드 교환
    public class TTSwapRule : TTRule
    {
        public override void ApplyRuleAt(TTRuleContext ruleContext)
        {

        }
    }
    #endregion

    #region Card Condition Rules
    
    // 역전: 
    public class TTReverseRule : TTRule
    {
        public override void ApplyRuleAt(TTRuleContext ruleContext)
        {
            ruleContext.reverseRankComparison = true;
        }
    }

    // 에이스 약화
    public class TTFallenAceRule : TTRule
    {
        public override void ApplyRuleAt(TTRuleContext ruleContext)
        {
            ruleContext.rankComapareFunction = CompareAceFalling;
        }
    }

    // 동수
    public class TTSameRule : TTRule
    {
        public override void ApplyRuleAt(TTRuleContext ruleContext)
        {

        }
    }

    // 합산
    public class TTPlusRule : TTRule
    {
        public override void ApplyRuleAt(TTRuleContext ruleContext)
        {

        }
    }

    // 유형 강화
    public class TTAscensionRule : TTRule
    {
        public override void ApplyRuleAt(TTRuleContext ruleContext)
        {

        }
    }

    // 유형 약화
    public class TTDescensionRule : TTRule
    {
        public override void ApplyRuleAt(TTRuleContext ruleContext)
        {

        }
    }
    #endregion
}