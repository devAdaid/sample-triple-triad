using UnityEngine;
using UnityEngine.UI;

namespace Ahyeong.TripleTride.UI
{
    public class TTCardUI : MonoBehaviour
    {
        [SerializeField] private GameObject _cardParent = null;
        [SerializeField] private Text _rankUpText = null;
        [SerializeField] private Text _rankRightText = null;
        [SerializeField] private Text _rankDownText = null;
        [SerializeField] private Text _rankLeftText = null;
        [SerializeField] private Image backgroundImg = null;

        [HideInInspector] public TTCard card = null;

        public void UpdateUI(TTCard updateCard)
        {
            card = updateCard;
            if (card != null)
            {
                _cardParent.SetActive(true);

                TTCardData cardData = card.cardData;
                _rankUpText.text = GetRankString(cardData.rankUp);
                _rankRightText.text = GetRankString(cardData.rankRight);
                _rankDownText.text = GetRankString(cardData.rankDown);
                _rankLeftText.text = GetRankString(cardData.rankLeft);
                backgroundImg.color = TTGameView.Instance.GetCardColorOf(card.belongPlayerId);
            }
            else
            {
                _cardParent.SetActive(false);
            }
        }

        public string GetRankString(int rank)
        {
            if (rank < 10) return rank.ToString();
            return "A";
        }
    }
}