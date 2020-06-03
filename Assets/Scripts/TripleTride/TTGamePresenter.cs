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
            for(int playerId = 0; playerId < _gameModel.PlayerCount; playerId++)
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
        public void UpdatePlayer(int playerNumber)
        {
            _onPlayerUpdate.Invoke(playerNumber);
        }

        [SerializeField] private UnityEvent _onResultUpdate = null;
        public void UpdateResult()
        {
            _onResultUpdate.Invoke();
        }
        #endregion

        #region Update Model
        public void ChangeGameState(EGameState state)
        {
            _gameModel.ChangeState(state);
        }

        public void PutCard(TTCard card, int i, int j)
        {
            _gameModel.PutCardOnBoard(card, i, j);
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

        public TTPlayer GetPlayer(int id)
        {
            return _gameModel.GetPlayer(id);
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

        public bool IsCardExistAt(int index_i, int index_j)
        {
            return _gameModel.board.IsCardExistAt(index_i, index_j);
        }

        public List<int> GetWinPlayers()
        {
            return _gameModel.GetPlayersHoldingMaximumCard();
        }

        #endregion
    }
}