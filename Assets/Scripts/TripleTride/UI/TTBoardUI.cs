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

            for (int i = 0; i < boardHeight; i++)
            {
                for (int j = 0; j < boardWidth; j++)
                {
                    slotUIs[i, j] = Instantiate(_slotUIPrefab, _slotParent);
                    slotUIs[i, j].InitializeUI(i, j);
                }
            }
        }

        public void UpdateUI(TTBoard board)
        {
            for (int j = 0; j < board.Width; j++)
            {
                for (int i = 0; i < board.Height; i++)
                {
                    slotUIs[i, j].UpdateUI(board.GetCardAt(i, j));
                }
            }
        }
    }
}