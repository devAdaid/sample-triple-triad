using UnityEngine;

namespace Ahyeong.TripleTride.UI
{
    [RequireComponent(typeof(TTCardUI))]
    public class TTCardSelect : MonoBehaviour
    {
        private TTCardUI _cardUI = null;

        private void Awake()
        {
            _cardUI = GetComponent<TTCardUI>();
        }

        public void OnSelectCard()
        {
            TTGameView.Instance.SelectCard(_cardUI.card);
        }
    }
}