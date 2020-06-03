using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Ahyeong.TripleTride.UI
{
    public class TTSelectRuleUI : MonoBehaviour
    {
        public TTRuleEntry ruleEntryPrefab;
        public Transform entryParent;
        private List<TTRuleEntry> _ruleEntries = new List<TTRuleEntry>();

        public void InitializeUI()
        {
            gameObject.SetActive(true);

            TTRule[] rules =  { new TTReverseRule(), new TTFallenAceRule()};

            var entries = entryParent.GetComponentsInChildren<TTRuleEntry>();
            for(int i = 0; i < rules.Length; i++)
            {
                TTRuleEntry entry = null;
                if (i < entries.Length)
                {
                    entry = entries[i];
                }
                else
                {
                    entry = Instantiate(ruleEntryPrefab, entryParent);
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
            TTRuleEntry newEntry = Instantiate(ruleEntryPrefab, entryParent);
            newEntry.SetWithRule(rule);
            _ruleEntries.Add(newEntry);
        }
    }
}