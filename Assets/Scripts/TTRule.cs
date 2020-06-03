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
        public override string Description => "상대 카드보다 숫자가 낮아야 지배할 수 있습니다.";

        public override void ApplyRuleAt(TTRuleContext ruleContext)
        {
            ruleContext.afterCompareCallback += (ref int result) => { return -result; };
        }
    }

    // 에이스 약화
    public class TTFallenAceRule : TTRule
    {
        public override string Name => "에이스 약화";
        public override string Description => "A를 1로 지배할 수 있습니다. '역전'이 적용된 경우 1을 A로 지배할 수 있습니다.";

        public override void ApplyRuleAt(TTRuleContext ruleContext)
        {
            ruleContext.rankComaparison = CompareAceFalling;
        }
    }
    
    // 유형 강화
    public class TTAscensionRule : TTRule
    {
        public override string Description => "같은 유형의 카드가 배치된 매수만큼 해당 유형의 카드 숫자가 높아집니다.";
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