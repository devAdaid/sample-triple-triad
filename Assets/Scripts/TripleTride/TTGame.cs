using System.Collections.Generic;
using UnityEngine;

namespace Ahyeong.TripleTride
{
    public enum EGameState
    {
        Ready,
        Playing,
        End
    }

    public class TTGame : MonoBehaviour
    {
        [SerializeField] private TTGamePresenter _presenter = null;
        [SerializeField] private int _boardSize = 3;
        [SerializeField] private int _playerCount = 2;

        public TTBoard board;
        public List<TTPlayer> players = new List<TTPlayer>();
        public int currentPlayerId = 0;

        public int PlayerCount => players.Count;
        public int TotalCardCount => _usedCards.Count;

        private List<TTRule> _rules = new List<TTRule>();
        private TTRuleContext _ruleContext = new TTRuleContext();
        private EGameState _gameState = EGameState.Ready;
        private List<TTCard> _usedCards = new List<TTCard>();

        void Awake()
        {
            board = new TTBoard(_boardSize, _boardSize, _ruleContext);
            int deckCard = (board.SlotCount + 1) / _playerCount;
            for(int i = 0; i < _playerCount; i++)
            {
                TTPlayer newPlayer = new TTPlayer(i, TTCardDatabase.Instance.GetRandomCardData(deckCard), $"플레이어{i + 1}");
                players.Add(newPlayer);
                _usedCards.AddRange(newPlayer.handCard);
            }

            SetFirstPlayerRandomly();

            _presenter.Initialize();
            _presenter.UpdateAllPlayUI();
        }

        public void PutCardOnBoard(TTCard card, int index_i, int index_j)
        {
            board.PutCard(card, index_i, index_j);
            players[card.belongPlayerId].RemoveCard(card);

            if (board.IsBoardFull())
            {
                ChangeState(EGameState.End);
                _presenter.UpdateResult();
            }
            else
            {
                TurnToNextPlayer();
            }

            _presenter.UpdateAllPlayUI();
        }

        public void TurnToNextPlayer()
        {
            currentPlayerId += 1;
            if (currentPlayerId >= PlayerCount)
            {
                currentPlayerId = 0;
            }
        }

        public int SelectRandomPlayerId()
        {
            if (players != null && PlayerCount > 0)
            {
                return Random.Range(0, PlayerCount);
            }

            Debug.LogError("Player does not exist.");
            return -1;
        }

        public void ApplyRules(List<TTRule> rules)
        {
            _rules = rules;
            _ruleContext.ResetRules();

            foreach(TTRule rule in _rules)
            {
                rule.ApplyRuleAt(_ruleContext);
            }
        }

        public bool IsPlayerInputActive(int playerId)
        {
            return (_gameState == EGameState.Playing) && (currentPlayerId == playerId);
        }

        public void ChangeState(EGameState state)
        {
            _gameState = state;
            _presenter.UpdateAllPlayUI();
        }

        public int[] GetPlayerScores()
        {
            int[] cardCounts = new int[PlayerCount];
            foreach (TTCard card in _usedCards)
            {
                cardCounts[card.belongPlayerId] += 1;
            }
            return cardCounts;
        }

        public List<int> GetPlayersHoldingMaximumCard()
        {
            int[] cardCounts = new int[PlayerCount];
            int maxHoldingCardCount = 0;
            foreach(TTCard card in _usedCards)
            {
                cardCounts[card.belongPlayerId] += 1;

                if (cardCounts[card.belongPlayerId] > maxHoldingCardCount)
                {
                    maxHoldingCardCount = cardCounts[card.belongPlayerId];
                }
            }

            List<int> playersHoldingMaxCard = new List<int>();
            for(int playerId = 0; playerId < PlayerCount; playerId++)
            {
                if (cardCounts[playerId] == maxHoldingCardCount)
                {
                    playersHoldingMaxCard.Add(playerId);
                }
            }
            return playersHoldingMaxCard;
        }

        public TTPlayer GetPlayer(int playerId)
        {
            if (playerId < PlayerCount)
            {
                return players[playerId];
            }

            Debug.LogError($"Player with ID: {playerId} does not exist.");
            return null;
        }

        private void SetFirstPlayerRandomly()
        {
            currentPlayerId = SelectRandomPlayerId();
        }
    }
}