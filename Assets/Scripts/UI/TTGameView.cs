using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ahyeong.TripleTride.UI
{
    public class TTGameView : MonoBehaviour
    {
        public TTGamePresenter presenter;
        public TTBoardUI boardUI;
        public List<TTPlayerUI> playerUI;

        #region Initialize UI
        public void Initialize()
        {
            Debug.Log("Init");
            InitializeBoardUI();
            InitializePlayerUI();
        }

        public void InitializeBoardUI()
        {
            var board = presenter.GetBoard();
            boardUI.Initialize(board.Width, board.Height);
        }

        public void InitializePlayerUI()
        {
            for(int i = 0; i < playerUI.Count; i++)
            {
                playerUI[i].InitializeUI(presenter.GetPlayer(i));
            }
        }
        #endregion

        #region Update UI
        public void UpdateBoardUI()
        {
            var board = presenter.GetBoard();
            boardUI.UpdateUI(board);
        }

        public void UpdatePlayerUI(int playerNumber)
        {
            playerUI[playerNumber].UpdateUI(presenter.GetPlayer(playerNumber), presenter.GetPlayerMoveState(playerNumber));
        }

        public void UpdateGameStateUI()
        {

        }
        #endregion

        #region User Inputs
        public TTCard selectedCard = null;

        public void SelectSlot(int slot_i, int slot_j)
        {
            // 카드 선택중이고 슬롯에 카드가 놓여있는지
            // 그렇다면 카드 놓고 턴처리
            if(selectedCard != null)
            {
                if (!presenter.IsCardExistAt(slot_i, slot_j))
                {
                    presenter.PutCard(selectedCard, slot_i, slot_j);
                    selectedCard = null;
                }
            }
        }

        public void SelectCard(TTCard card)
        {
            if(presenter.GetCurrentPlayer() == card.ownPlayer)
            {
                selectedCard = card;
            }
            else
            {
                Debug.Log("Not player's turn");
            }
        }
        #endregion
    }
}