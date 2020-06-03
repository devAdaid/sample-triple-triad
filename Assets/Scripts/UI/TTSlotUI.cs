using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ahyeong.TripleTride.UI
{
    public class TTSlotUI : MonoBehaviour
    {
        public TTCardUI cardUI;
        [SerializeField]
        private int _slot_i = 0;
        [SerializeField]
        private int _slot_j = 0;

        public void InitializeUI(int i, int j)
        {
            _slot_i = i;
            _slot_j = j;
        }

        public void UpdateUI(TTCard card)
        {
            cardUI.UpdateUI(card);
        }

        public void OnSelectSlot()
        {
            TTGameView view = FindObjectOfType<TTGameView>();
            view.SelectSlot(_slot_i, _slot_j);
        }
    }
}