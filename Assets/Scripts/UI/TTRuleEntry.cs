using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ahyeong.TripleTride.UI
{
    public class TTRuleEntry : MonoBehaviour
    {
        public Text nameText;
        public Text descriptionText;
        public TTRule rule;

        public bool isSelected = false;

        public void SetWithRule(TTRule rule)
        {
            nameText.text = rule.Name;
            descriptionText.text = rule.Description;
            this.rule = rule;
        }

        public void OnSelectionChanged(bool flag)
        {
            isSelected = flag;
        }
    }
}