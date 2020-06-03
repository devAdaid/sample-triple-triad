using UnityEngine;

namespace Ahyeong.TripleTride.UI
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
            
            for (int i = 0; i < cardCount; i++)
            {
                _cardUIs[i] = Instantiate(_playerCardUIPrefab, _cardParent);
                _cardUIs[i].UpdateUI(player.handCard[i]);
            }
        }

        public void UpdateUI(TTPlayer player, bool playerInputActive)
        {
            int cardCount = player.handCard.Count;
            for (int i = 0; i < cardCount; i++)
            {
                _cardUIs[i].UpdateUI(player.handCard[i]);
            }

            _inputBlocker.SetActive(!playerInputActive);
        }
    }
}