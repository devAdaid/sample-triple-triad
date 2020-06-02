using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Ahyeong.TripleTride
{
    [System.Serializable]
    public class IntEvent : UnityEvent<int> { }

    public class TTGamePresenter : MonoBehaviour
    {
        public TTGame gameModel;

        public UnityEvent onInitialize;
        public void Initialize()
        {
            onInitialize.Invoke();
        }

        #region Update UI
        public UnityEvent onBoardUpdate;
        public void UpdateBoard()
        {
            onBoardUpdate.Invoke();
        }

        public IntEvent onPlayerUpdate;
        public void UpdatePlayer(int playerNumber)
        {
            onPlayerUpdate.Invoke(playerNumber);
        }
        #endregion

        #region Retrieve data
        public TTBoard GetBoard()
        {
            return gameModel.board;
        }

        public TTPlayer GetPlayer(int number)
        {
            return gameModel.players[number];
        }

        public int GetCurrentPlayer()
        {
            return gameModel.currentPlayerIndex;
        }

        public bool IsCardExistAt(int board_i, int board_j)
        {
            return gameModel.board.IsCardExistAt(board_i, board_j);
        }

        #endregion

        #region Update Model
        public void PutCard(TTCard card, int i, int j)
        {
            gameModel.PutCardOnBoard(card, i, j);
        }
        #endregion
    }
}