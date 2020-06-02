using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ahyeong.TripleTride
{
    public class TTBoard
    {
        public TTCard[,] board;
        public int Width => board.GetUpperBound(1) + 1;
        public int Height => board.GetUpperBound(0) + 1;
        public int SlotCount => board.Length;

        public TTBoard(int boardWidth, int boardHeight)
        {
            board = new TTCard[boardHeight, boardWidth];
        }

        public void PutCard(TTCard card, int i, int j)
        {
            if(IsCardExistAt(i, j))
            {
                Debug.Log("");
                return;
            }

            board[i, j] = card;
        }

        public void OnTypeAdded()
        {

        }

        public bool IsCardExistAt(int i, int j)
        {
            return board[i, j] != null;
        }
    }
}