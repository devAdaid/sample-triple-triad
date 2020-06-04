using UnityEngine;

namespace Ahyeong.TripleTride.UI
{
    public class TTSlotUI : MonoBehaviour
    {
        public TTCardUI cardUI;
        [SerializeField] private int _indexOfRow = 0;
        [SerializeField] private int _indexOfColumn = 0;

        public void InitializeUI(int indexOfRow, int indexOfColumn)
        {
            _indexOfRow = indexOfRow;
            _indexOfColumn = indexOfColumn;
        }

        public void UpdateUI(TTCard card)
        {
            cardUI.UpdateUI(card);
        }

        public void OnSelectSlot()
        {
            TTGameView.Instance.SelectSlot(_indexOfRow, _indexOfColumn);
        }
    }
}