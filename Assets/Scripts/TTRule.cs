using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ahyeong.TripleTride
{
    public abstract class TTRule
    {
        public virtual string Name => string.Empty;
        public virtual string Description => string.Empty;
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
    
    #region Card Condition Rules
    
    // 역전: 
    public class TTReverseRule : TTRule
    {
        public override string Name => "역전";
        public override string Description => "";

        public override void ApplyRuleAt(TTRuleContext ruleContext)
        {
            ruleContext.afterCompareCallback += (ref int result) => { return -result; };
        }
    }

    // 에이스 약화
    public class TTFallenAceRule : TTRule
    {
        public override string Name => "에이스 약화";
        public override string Description => "";

        public override void ApplyRuleAt(TTRuleContext ruleContext)
        {
            ruleContext.rankComaparison = CompareAceFalling;
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