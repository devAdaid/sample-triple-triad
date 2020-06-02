using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Ahyeong.TripleTride
{
    public class TTCardDatabase : Singleton<TTCardDatabase>
    {
        public TTCardData[] cardData = null;

        private const string dataPath = "Cards";

        public TTCardDatabase()
        {
            cardData = Resources.LoadAll<TTCardData>(dataPath);
        }

        public List<TTCardData> GetRandomCardData(int dataCount)
        {
            if(dataCount > cardData.Length)
            {
                Debug.Log("Card ~");
                return null;
            }

            List<TTCardData> cards = new List<TTCardData>();
            int[] candidates = Enumerable.Range(0, cardData.Length).ToArray();
            int candidateRange = candidates.Length;

            for(int i = 0; i < dataCount; i++)
            {
                int randomCandidateIndex = Random.Range(0, candidateRange);
                int newCardIndex = candidates[randomCandidateIndex];
                Swap(ref candidates[randomCandidateIndex], ref candidates[candidateRange - 1]);
                candidateRange -= 1;

                TTCardData newCard = cardData[newCardIndex];
                cards.Add(newCard);
            }

            return cards;
        }

        private void Swap(ref int value1, ref int value2)
        {
            int temp = value1;
            value1 = value2;
            value2 = temp;
        }
    }
}