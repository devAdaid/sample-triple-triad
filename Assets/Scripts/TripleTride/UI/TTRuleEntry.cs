using UnityEngine;
using UnityEngine.UI;

namespace Ahyeong.TripleTride.UI
{
    public class TTRuleEntry : MonoBehaviour
    {
        [SerializeField] private Text _nameText = null;
        [SerializeField] private Text _descriptionText = null;

        [HideInInspector] public TTRule rule;

        public bool isSelected = false;

        public void SetWithRule(TTRule entryRule)
        {
            _nameText.text = entryRule.Name;
            _descriptionText.text = entryRule.Description;
            rule = entryRule;
        }

        public void OnSelectionChanged(bool flag)
        {
            isSelected = flag;
        }
    }
}