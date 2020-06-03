using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ahyeong.TripleTride
{
    [System.Serializable]
    public class TTPlayer
    {
        public string playerName = string.Empty;
        public int playerNumber = 0;
        public List<TTCardData> playerDeck = new List<TTCardData>();
        public List<TTCard> playerHand = new List<TTCard>();

        public TTPlayer(int number, List<TTCardData> deck, string name = "")
        {
            playerNumber = number;
            playerDeck = deck;
            playerName = name;
            SetHandWithDeck();
        }

        public void SetHandWithDeck()
        {
            playerHand.Clear();
            foreach(var cardData in playerDeck)
            {
                playerHand.Add(new TTCard(cardData, playerNumber));
            }
        }

        public void RemoveCard(TTCard card)
        {
            int removeIndex = playerHand.IndexOf(card);
            playerHand[removeIndex] = null;
        }

        public void SetDeck(List<TTCardData> newDeck)
        {
            playerDeck = newDeck;
        }
    }
}