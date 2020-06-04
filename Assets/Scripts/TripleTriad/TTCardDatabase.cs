using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Ahyeong.TripleTriad
{
    public class TTCardDatabase : Singleton<TTCardDatabase>
    {
        private TTCardData[] _cardData = null;

        private const string dataPath = "Cards";

        public TTCardDatabase()
        {
            _cardData = Resources.LoadAll<TTCardData>(dataPath);
        }

        public List<TTCardData> GetRandomCardData(int count)
        {
            if (count > _cardData.Length)
            {
                Debug.LogError($"Card data is less than request count {count}");
                return null;
            }

            List<TTCardData> randomCards = new List<TTCardData>();
            int[] candidatesOfIndex = Enumerable.Range(0, _cardData.Length).ToArray();
            int candidateRange = candidatesOfIndex.Length;

            for (int i = 0; i < count; i++)
            {
                int randomCandidateIndex = Random.Range(0, candidateRange);
                int newCardIndex = candidatesOfIndex[randomCandidateIndex];
                Swap(ref candidatesOfIndex[randomCandidateIndex], ref candidatesOfIndex[candidateRange - 1]);
                candidateRange -= 1;

                TTCardData newCard = _cardData[newCardIndex];
                randomCards.Add(newCard);
            }

            return randomCards;
        }

        private void Swap(ref int value1, ref int value2)
        {
            int temp = value1;
            value1 = value2;
            value2 = temp;
        }
    }
}