using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Ahyeong.TripleTride.UI
{
    public class TTSelectRuleUI : MonoBehaviour
    {
        [SerializeField] private TTRuleEntry _ruleEntryPrefab = null;
        [SerializeField] private Transform _entryParent = null;

        private List<TTRuleEntry> _ruleEntries = new List<TTRuleEntry>();

        public void InitializeUI()
        {
            gameObject.SetActive(true);

            TTRule[] rules =  { new TTReverseRule(), new TTFallenAceRule()};

            var entries = _entryParent.GetComponentsInChildren<TTRuleEntry>();
            for(int i = 0; i < rules.Length; i++)
            {
                TTRuleEntry entry = null;
                if (i < entries.Length)
                {
                    entry = entries[i];
                }
                else
                {
                    entry = Instantiate(_ruleEntryPrefab, _entryParent);
                }

                entry.SetWithRule(rules[i]);
                _ruleEntries.Add(entry);
            }
        }

        public void SelectRules()
        {
            List<TTRule> rules = _ruleEntries.Where(e => e.isSelected).Select(e => e.rule).ToList();
            TTGameView.Instance.SelectRules(rules);
        }

        private void MakeRuleEntry(TTRule rule)
        {
            TTRuleEntry newEntry = Instantiate(_ruleEntryPrefab, _entryParent);
            newEntry.SetWithRule(rule);
            _ruleEntries.Add(newEntry);
        }
    }
}