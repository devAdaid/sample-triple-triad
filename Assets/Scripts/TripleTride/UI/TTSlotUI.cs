using UnityEngine;

namespace Ahyeong.TripleTride.UI
{
    public class TTSlotUI : MonoBehaviour
    {
        public TTCardUI cardUI;
        [SerializeField] private int _slotIndex_i = 0;
        [SerializeField] private int _slotIndex_j = 0;

        public void InitializeUI(int index_i, int index_j)
        {
            _slotIndex_i = index_i;
            _slotIndex_j = index_j;
        }

        public void UpdateUI(TTCard card)
        {
            cardUI.UpdateUI(card);
        }

        public void OnSelectSlot()
        {
            TTGameView.Instance.SelectSlot(_slotIndex_i, _slotIndex_j);
        }
    }
}