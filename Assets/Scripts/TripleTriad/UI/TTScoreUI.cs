using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ahyeong.TripleTriad.UI
{
    public class TTScoreUI : MonoBehaviour
    {
        [SerializeField] private Image _scoreIconPrefab = null;
        [SerializeField] private Transform _scoreParent = null;

        private List<Image> _scoreIcons = new List<Image>();

        public void InitializeUI(int totalCardCount)
        {
            for (int card = 0; card < totalCardCount; card++)
            {
                Image icon = Instantiate(_scoreIconPrefab, _scoreParent);
                _scoreIcons.Add(icon);
            }
        }

        public void UpdateUI(int[] cardCountOfPlayers)
        {
            int indexOfLastUpdatedIcon = 0;
            for (int playerId = 0; playerId < cardCountOfPlayers.Length; playerId++)
            {
                int score = cardCountOfPlayers[playerId];
                for (int icon = indexOfLastUpdatedIcon; icon < indexOfLastUpdatedIcon + score; icon++)
                {
                    _scoreIcons[icon].color = TTGameView.Instance.GetCardColorOf(playerId);
                }
                indexOfLastUpdatedIcon += score;
            }
        }
    }
}