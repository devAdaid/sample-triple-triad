using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Ahyeong.TripleTriad.UI
{
    public class TTResultUI : MonoBehaviour
    {
        [SerializeField] private Text _resultText = null;
        [SerializeField] private Image _backgroundImg = null;

        public void UpdateUI(List<int> winPlayers)
        {
            gameObject.SetActive(true);

            if (winPlayers.Count == 1)
            {
                int winPlayer = winPlayers[0];
                _resultText.text = $"플레이어 {winPlayer + 1} 승리!";

                _backgroundImg.color = TTGameView.Instance.GetUIColorOf(winPlayer);
            }
            else
            {
                _resultText.text = "무승부";

                List<Color> winPlayerColors = winPlayers.Select(player => TTGameView.Instance.GetUIColorOf(player)).ToList();
                _backgroundImg.color = MixColors(winPlayerColors);
            }
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(0);
        }

        public void QuitGame()
        {
#if !UNITY_EDITOR
        Application.Quit();
#else
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }

        private Color MixColors(List<Color> colors)
        {
            if (colors == null || colors.Count == 0)
            {
                return Color.white;
            }

            Color mixedColor = colors[0];
            for (int color = 1; color < colors.Count; color++)
            {
                mixedColor += colors[color];
            }
            mixedColor /= colors.Count;

            return mixedColor;
        }
    }
}