using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ahyeong.TripleTride
{
    public class TTBoard
    {
        public TTCard[,] board;

        public TTBoard(int boardWidth, int boardHeight)
        {
            board = new TTCard[boardWidth, boardHeight];
        }

        public void PutCard(TTCard card, int i, int j)
        {
            if(CardExistAt(i, j))
            {
                Debug.Log("");
                return;
            }

            board[i][j] = card;


        }

        public void OnTypeAdded()
        {

        }

        public bool CardExistAt(int i, int j)
        {
            return board[i][j] != null;
        }
    }
}