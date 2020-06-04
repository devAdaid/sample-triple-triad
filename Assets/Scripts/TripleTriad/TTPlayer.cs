using System.Collections.Generic;

namespace Ahyeong.TripleTriad
{
    [System.Serializable]
    public class TTPlayer
    {
        public string name = string.Empty;
        public int id = 0;
        public List<TTCard> handCard = new List<TTCard>();

        public TTPlayer(int playerId, List<TTCardData> deck, string playerName = "")
        {
            id = playerId;
            name = playerName;
            SetHandWithDeck(deck);
        }

        public void SetHandWithDeck(List<TTCardData> deck)
        {
            handCard.Clear();
            foreach(var cardData in deck)
            {
                handCard.Add(new TTCard(cardData, id));
            }
        }

        public void RemoveCard(TTCard card)
        {
            int removeIndex = handCard.IndexOf(card);
            handCard[removeIndex] = null;
        }
    }
}