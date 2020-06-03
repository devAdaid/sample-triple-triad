using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ahyeong.TripleTride.UI
{
    public class TTCardUI : MonoBehaviour
    {
        public GameObject cardChild;
        public TTCard card;
        public Text rankUpText;
        public Text rankRightText;
        public Text rankDownText;
        public Text rankLeftText;
        public Image backgroundImg;

        public void UpdateUI(TTCard card)
        {
            this.card = card;
            if(card != null)
            {
                cardChild.SetActive(true);

                TTCardData cardData = card.cardData;
                rankUpText.text = GetRankString(cardData.rankUp);
                rankRightText.text = GetRankString(cardData.rankRight);
                rankDownText.text = GetRankString(cardData.rankDown);
                rankLeftText.text = GetRankString(cardData.rankLeft);
                backgroundImg.color = TTGameView.Instance.GetCardColorOf(card.ownPlayer);
            }
            else
            {
                cardChild.SetActive(false);
            }
        }

        public string GetRankString(int rank)
        {
            if (rank < 10) return rank.ToString();
            return "A";
        }
    }
}