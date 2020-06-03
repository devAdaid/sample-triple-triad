using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ahyeong.TripleTride.UI
{
    public class TTScoreUI : MonoBehaviour
    {
        [SerializeField] private Image _scoreIconPrefab = null;
        [SerializeField] private Transform _scoreParent = null;

        private List<Image> _scoreIcons = new List<Image>();

        public void InitializeUI(int totalCardCount)
        {
            for(int i = 0; i < totalCardCount; i++)
            {
                Image icon = Instantiate(_scoreIconPrefab, _scoreParent);
                _scoreIcons.Add(icon);
            }
        }

        public void UpdateUI(int[] cardCountOfPlayers)
        {
            int indexOfLastUpdatedIcon = 0;
            for(int player = 0; player < cardCountOfPlayers.Length; player++)
            {
                int score = cardCountOfPlayers[player];
                for(int j = indexOfLastUpdatedIcon; j < indexOfLastUpdatedIcon + score; j++)
                {
                    _scoreIcons[j].color = TTGameView.Instance.GetCardColorOf(player);
                }
                indexOfLastUpdatedIcon += score;
            }
        }
    }
}