using System.Collections;
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
        public TTGamePresenter presenter;
        public int boardSize = 3;
        public int playerCount = 2;
        public TTBoard board;
        public List<TTPlayer> players = new List<TTPlayer>();
        public int MaxPlayerCount => players.Count;
        public int TotalCardCount => usedCards.Count;
        public int currentPlayerIndex = 0;
        private List<TTRule> _rules = new List<TTRule>();
        private TTRuleContext _ruleContext = new TTRuleContext();
        public EGameState gameState = EGameState.Ready;
        public List<TTCard> usedCards = new List<TTCard>();

        void Awake()
        {
            board = new TTBoard(boardSize, boardSize, _ruleContext);
            int deckCard = (board.slots.Length + 1) / playerCount;
            for(int i = 0; i < playerCount; i++)
            {
                TTPlayer newPlayer = new TTPlayer(i, TTCardDatabase.Instance.GetRandomCardData(deckCard), $"플레이어{i + 1}");
                players.Add(newPlayer);
                usedCards.AddRange(newPlayer.playerHand);
            }
            presenter.Initialize();
            UpdateUI();
        }

        public void PutCard()
        {
            UpdateUI();
        }

        public void PutCardOnBoard(TTCard card, int i, int j)
        {
            board.PutCard(card, i, j);
            players[card.ownPlayer].RemoveCard(card);

            if(board.IsBoardFull())
            {
                ChangeState(EGameState.End);
                presenter.UpdateResult();
            }
            else
            {
                NextTurn();
            }

            UpdateUI();
        }

        public void SetFirstPlayer()
        {
            currentPlayerIndex = SelectRandomPlayer();
        }

        public void NextTurn()
        {
            currentPlayerIndex += 1;
            if(currentPlayerIndex >= MaxPlayerCount)
            {
                currentPlayerIndex = 0;
            }
        }

        public int SelectRandomPlayer()
        {
            if(players != null && MaxPlayerCount > 0)
            {
                int maxPlayer = players.Count;
                return Random.Range(0, maxPlayer);
            }

            Debug.LogError("No players");
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

        public bool CanPlayerMove(int playerNumber)
        {
            return gameState == EGameState.Playing && currentPlayerIndex == playerNumber;
        }

        public void ChangeState(EGameState state)
        {
            gameState = state;
            UpdateUI();
        }

        public int[] GetPlayerScores()
        {
            int[] cardCounts = new int[playerCount];
            foreach (TTCard card in usedCards)
            {
                cardCounts[card.ownPlayer] += 1;
            }
            return cardCounts;
        }

        public List<int> GetPlayersHoldingMaxCard()
        {
            int[] cardCounts = new int[playerCount];
            int maxHoldingCardCount = 0;
            foreach(TTCard card in usedCards)
            {
                cardCounts[card.ownPlayer] += 1;
                if(cardCounts[card.ownPlayer] > maxHoldingCardCount)
                {
                    maxHoldingCardCount = cardCounts[card.ownPlayer];
                }
            }

            List<int> playersHoldingMaxCard = new List<int>();
            for(int player = 0; player < playerCount; player++)
            {
                if(cardCounts[player] == maxHoldingCardCount)
                {
                    playersHoldingMaxCard.Add(player);
                }
            }
            return playersHoldingMaxCard;
        }

        private void UpdateUI()
        {
            presenter.UpdateBoard();
            presenter.UpdatePlayer(0);
            presenter.UpdatePlayer(1);
        }
    }
}