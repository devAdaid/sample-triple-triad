namespace Ahyeong.TripleTriad
{
    public abstract class TTRule
    {
        public virtual string Name => string.Empty;
        public virtual string Description => string.Empty;

        public abstract void ApplyRuleAt(TTRuleContext ruleContext);
        
        public static int Compare(int value1, int value2)
        {
            return value1 - value2;
        }
    }
    
    #region Card Condition Rules
    
    public class TTReverseRule : TTRule
    {
        public override string Name => "역전";
        public override string Description => "상대 카드보다 숫자가 낮아야 지배할 수 있습니다.";

        public override void ApplyRuleAt(TTRuleContext ruleContext)
        {
            ruleContext.afterCompareCallback += (ref int result) => { return -result; };
        }
    }
    
    public class TTFallenAceRule : TTRule
    {
        public override string Name => "에이스 약화";
        public override string Description => "A를 1로 지배할 수 있습니다. '역전'이 적용된 경우 1을 A로 지배할 수 있습니다.";

        private const int Ace = 10;

        public override void ApplyRuleAt(TTRuleContext ruleContext)
        {
            ruleContext.rankComaparison = CompareAceFalling;
        }

        public int CompareAceFalling(int value1, int value2)
        {
            int result = Compare(value1, value2);

            if (value1 == Ace && value2 == 1)
            {
                result = -1;
            }
            else if (value2 == Ace && value1 == 1)
            {
                result = 1;
            }

            return result;
        }
    }
    #endregion
}