using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ahyeong.TripleTride.UI
{
    public class TTGameView : MonoSingleton<TTGameView>
    {
        public TTGamePresenter presenter;
        public TTSelectRuleUI selectRuleUI;
        public TTResultUI resultUI;
        public TTScoreUI scoreUI;
        public TTBoardUI boardUI;
        public List<TTPlayerUI> playerUI;

        #region Initialize UI
        public void Initialize()
        {
            InitializeSelectRuleUI();
            InitializeScoreUI();
            InitializeBoardUI();
            InitializePlayerUI();
        }

        public void InitializeSelectRuleUI()
        {
            selectRuleUI.InitializeUI();
        }

        public void InitializeScoreUI()
        {
            scoreUI.InitializeUI(presenter.GetTotalCardCount());
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
        public void UpdateScoreUI()
        {
            var score = presenter.GetPlayerScores();
            scoreUI.UpdateUI(score);
        }

        public void UpdateBoardUI()
        {
            var board = presenter.GetBoard();
            boardUI.UpdateUI(board);
        }

        public void UpdatePlayerUI(int playerNumber)
        {
            playerUI[playerNumber].UpdateUI(presenter.GetPlayer(playerNumber), presenter.GetPlayerMoveState(playerNumber));
        }

        public void UpdateResultUI()
        {
            var winPlayers = presenter.GetWinPlayers();
            resultUI.UpdateUI(winPlayers);
        }
        #endregion

        #region User Inputs
        public TTCard selectedCard = null;

        public void SelectSlot(int slot_i, int slot_j)
        {
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
                Debug.LogWarning("Not player's turn");
            }
        }

        public void SelectRules(List<TTRule> rules)
        {
            presenter.ApplyRules(rules);
            presenter.ChangeGameState(EGameState.Playing);
        }
        #endregion

        public Color GetCardColorOf(int playerNumber)
        {
            if(playerNumber < playerUI.Count)
            {
                return playerUI[playerNumber].cardColor;
            }

            Debug.LogWarning($"Player {playerNumber} not exist");
            return Color.black;
        }

        public Color GetUIColorOf(int playerNumber)
        {
            if (playerNumber < playerUI.Count)
            {
                return playerUI[playerNumber].uiColor;
            }

            Debug.LogWarning($"Player {playerNumber} not exist");
            return Color.black;
        }
    }
}