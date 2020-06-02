using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ahyeong.TripleTride
{
    public class TTGame : MonoBehaviour
    {
        public TTGamePresenter presenter;
        public TTBoard board = new TTBoard(3, 3);
        public List<TTPlayer> players = new List<TTPlayer>();
        public int MaxPlayerCount => players.Count;
        public int currentPlayerIndex = 0;

        void Awake()
        {
            players.Add(new TTPlayer(0, TTCardDatabase.Instance.GetRandomCardData(5), "플레이어1"));
            players.Add(new TTPlayer(1, TTCardDatabase.Instance.GetRandomCardData(5), "플레이어2"));
            presenter.Initialize();
        }

        public void PutCard()
        {
            UpdateUI();
        }

        public void PutCardOnBoard(TTCard card, int i, int j)
        {
            Debug.Log($"Put card at {i}, {j}");
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

        private void UpdateUI()
        {
            presenter.UpdateBoard();
            presenter.UpdatePlayer(0);
            presenter.UpdatePlayer(1);
        }
    }
}