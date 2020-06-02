using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ahyeong.TripleTride.UI
{
    public class TTBoardUI : MonoBehaviour
    {
        public TTSlotUI slotUIPrefab;
        public Transform slotParent;
        private TTSlotUI[,] slotUIs;

        public void Initialize(int boardWidth, int boardHeight)
        {
            slotUIs = new TTSlotUI[boardHeight, boardWidth];

            for (int j = 0; j < boardWidth; j++)
            {
                for (int i = 0; i < boardHeight; i++)
                {
                    slotUIs[i, j] = Instantiate(slotUIPrefab, slotParent);
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
                    slotUIs[i, j].UpdateUI(board.board[i, j]);
                }
            }
        }
    }
}