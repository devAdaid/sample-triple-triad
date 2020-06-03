using System.Collections.Generic;
using UnityEngine;

namespace Ahyeong.TripleTride.UI
{
    public class TTGameView : MonoSingleton<TTGameView>
    {
        [SerializeField] private TTGamePresenter _presenter = null;
        [SerializeField] private TTSelectRuleUI _selectRuleUI = null;
        [SerializeField] private TTScoreUI _scoreUI = null;
        [SerializeField] private TTBoardUI _boardUI = null;
        [SerializeField] private List<TTPlayerUI> _playerUI = new List<TTPlayerUI>();
        [SerializeField] private TTResultUI _resultUI = null;

        #region Initialize UI
        public void Initialize()
        {
            InitializeSelectRuleUI();
            InitializeScoreUI();
            InitializeBoardUI();
            InitializePlayerUI();
        }

        private void InitializeSelectRuleUI()
        {
            _selectRuleUI.InitializeUI();
        }

        private void InitializeScoreUI()
        {
            _scoreUI.InitializeUI(_presenter.GetTotalCardCount());
        }

        private void InitializeBoardUI()
        {
            var board = _presenter.GetBoard();
            _boardUI.InitializeUI(board.Width, board.Height);
        }

        private void InitializePlayerUI()
        {
            for(int i = 0; i < _playerUI.Count; i++)
            {
                _playerUI[i].InitializeUI(_presenter.GetPlayer(i));
            }
        }
        #endregion

        #region Update UI
        public void UpdateScoreUI()
        {
            var score = _presenter.GetPlayerScores();
            _scoreUI.UpdateUI(score);
        }

        public void UpdateBoardUI()
        {
            var board = _presenter.GetBoard();
            _boardUI.UpdateUI(board);
        }

        public void UpdatePlayerUI(int playerId)
        {
            TTPlayer player = _presenter.GetPlayer(playerId);
            bool playerInputActive = _presenter.GetPlayerMoveState(playerId);
            _playerUI[playerId].UpdateUI(player, playerInputActive);
        }

        public void UpdateResultUI()
        {
            var winPlayers = _presenter.GetWinPlayers();
            _resultUI.UpdateUI(winPlayers);
        }
        #endregion

        #region User Inputs
        private TTCard _selectedCard = null;

        public void SelectSlot(int slot_i, int slot_j)
        {
            if(_selectedCard != null)
            {
                if (!_presenter.IsCardExistAt(slot_i, slot_j))
                {
                    _presenter.PutCard(_selectedCard, slot_i, slot_j);
                    _selectedCard = null;
                }
            }
        }

        public void SelectCard(TTCard card)
        {
            if(_presenter.GetCurrentPlayer() == card.belongPlayerId)
            {
                _selectedCard = card;
            }
            else
            {
                Debug.LogWarning("Selected card not belong to current turn player.");
            }
        }

        public void SelectRules(List<TTRule> rules)
        {
            _presenter.ApplyRules(rules);
            _presenter.ChangeGameState(EGameState.Playing);
        }
        #endregion

        public Color GetCardColorOf(int playerId)
        {
            if(playerId < _playerUI.Count)
            {
                return _playerUI[playerId].cardColor;
            }

            Debug.LogWarning($"Player UI with ID: {playerId} not exist.");
            return Color.black;
        }

        public Color GetUIColorOf(int playerId)
        {
            if (playerId < _playerUI.Count)
            {
                return _playerUI[playerId].uiColor;
            }

            Debug.LogWarning($"Player UI with ID: {playerId} not exist.");
            return Color.black;
        }
    }
}