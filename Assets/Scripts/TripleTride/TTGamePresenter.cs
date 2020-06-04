using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Ahyeong.TripleTride
{
    [System.Serializable]
    public class IntEvent : UnityEvent<int> { }

    public class TTGamePresenter : MonoBehaviour
    {
        [SerializeField] private TTGame _gameModel = null;

        [SerializeField] private UnityEvent _onInitialize = null;
        public void Initialize()
        {
            _onInitialize.Invoke();
        }

        #region Update UI

        public void UpdateAllPlayUI()
        {
            UpdateBoard();
            for (int playerId = 0; playerId < _gameModel.PlayerCount; playerId++)
            {
                UpdatePlayer(playerId);
            }
        }

        [SerializeField] private UnityEvent _onBoardUpdate = null;
        public void UpdateBoard()
        {
            _onBoardUpdate.Invoke();
        }

        [SerializeField] private IntEvent _onPlayerUpdate = null;
        public void UpdatePlayer(int playerId)
        {
            _onPlayerUpdate.Invoke(playerId);
        }

        [SerializeField] private UnityEvent _onResultUpdate = null;
        public void UpdateResult()
        {
            _onResultUpdate.Invoke();
        }
        #endregion

        #region Update Model
        public void ChangeGameState(GameState state)
        {
            _gameModel.ChangeState(state);
        }

        public void PutCard(TTCard card, int indexOfRow, int indexOfColumn)
        {
            _gameModel.PutCardOnBoard(card, indexOfRow, indexOfColumn);
        }

        public void ApplyRules(List<TTRule> rules)
        {
            _gameModel.ApplyRules(rules);
        }
        #endregion

        #region Retrieve data
        public TTBoard GetBoard()
        {
            return _gameModel.board;
        }

        public TTPlayer GetPlayer(int playerId)
        {
            return _gameModel.GetPlayer(playerId);
        }

        public int GetTotalCardCount()
        {
            return _gameModel.TotalCardCount;
        }

        public int[] GetPlayerScores()
        {
            return _gameModel.GetPlayerScores();
        }

        public int GetCurrentPlayer()
        {
            return _gameModel.currentPlayerId;
        }

        public bool GetPlayerMoveState(int playerId)
        {
            return _gameModel.IsPlayerInputActive(playerId);
        }

        public bool IsCardExistAt(int indexOfRow, int indexOfColumn)
        {
            return _gameModel.board.IsCardExistAt(indexOfRow, indexOfColumn);
        }

        public List<int> GetWinPlayers()
        {
            return _gameModel.GetPlayersHoldingMaximumCard();
        }

        #endregion
    }
}