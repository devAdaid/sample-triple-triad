using UnityEngine;

namespace Ahyeong.TripleTride.UI
{
    public class TTBoardUI : MonoBehaviour
    {
        [SerializeField] public TTSlotUI _slotUIPrefab = null;
        [SerializeField] public Transform _slotParent = null;
        private TTSlotUI[,] slotUIs;

        public void InitializeUI(int boardWidth, int boardHeight)
        {
            slotUIs = new TTSlotUI[boardHeight, boardWidth];

            for (int row = 0; row < boardHeight; row++)
            {
                for (int col = 0; col < boardWidth; col++)
                {
                    slotUIs[row, col] = Instantiate(_slotUIPrefab, _slotParent);
                    slotUIs[row, col].InitializeUI(row, col);
                }
            }
        }

        public void UpdateUI(TTBoard board)
        {
            for (int row = 0; row < board.Height; row++)
            {
                for (int col = 0; col < board.Width; col++)
                {
                    slotUIs[row, col].UpdateUI(board.GetCardAt(row, col));
                }
            }
        }
    }
}