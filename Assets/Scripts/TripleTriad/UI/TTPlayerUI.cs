using UnityEngine;

namespace Ahyeong.TripleTriad.UI
{
    public class TTPlayerUI : MonoBehaviour
    {
        [SerializeField] public Color cardColor = Color.white;
        [SerializeField] public Color uiColor = Color.white;
        [SerializeField] private TTCardUI _playerCardUIPrefab = null;
        [SerializeField] private Transform _cardParent = null;
        [SerializeField] private GameObject _inputBlocker = null;

        private TTCardUI[] _cardUIs;

        public void InitializeUI(TTPlayer player)
        {
            int cardCount = player.handCard.Count;
            _cardUIs = new TTCardUI[cardCount];
            
            for (int card = 0; card < cardCount; card++)
            {
                _cardUIs[card] = Instantiate(_playerCardUIPrefab, _cardParent);
                _cardUIs[card].UpdateUI(player.handCard[card]);
            }
        }

        public void UpdateUI(TTPlayer player, bool playerInputActive)
        {
            int cardCount = player.handCard.Count;
            for (int card = 0; card < cardCount; card++)
            {
                _cardUIs[card].UpdateUI(player.handCard[card]);
            }

            _inputBlocker.SetActive(!playerInputActive);
        }
    }
}