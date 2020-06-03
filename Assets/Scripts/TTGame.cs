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
        public TTBoard board;
        public List<TTPlayer> players = new List<TTPlayer>();
        public int MaxPlayerCount => players.Count;
        public int currentPlayerIndex = 0;
        private List<TTRule> _rules = new List<TTRule>();
        private TTRuleContext _ruleContext = new TTRuleContext();
        public EGameState gameState = EGameState.Ready;

        void Awake()
        {
            board = new TTBoard(boardSize, boardSize, _ruleContext);
            int deckCard = (board.slots.Length + 1) / 2;
            players.Add(new TTPlayer(0, TTCardDatabase.Instance.GetRandomCardData(deckCard), "플레이어1"));
            players.Add(new TTPlayer(1, TTCardDatabase.Instance.GetRandomCardData(deckCard), "플레이어2"));
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
            NextTurn();
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

        public void SetRules(List<TTRule> rules)
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

            return true;
        }

        private void UpdateUI()
        {
            presenter.UpdateBoard();
            presenter.UpdatePlayer(0);
            presenter.UpdatePlayer(1);
        }
    }
}