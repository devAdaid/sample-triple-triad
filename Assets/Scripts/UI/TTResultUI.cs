using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Ahyeong.TripleTride.UI
{
    public class TTResultUI : MonoBehaviour
    {
        public Text resultText;
        public Image backgroundImg;

        public void UpdateUI(List<int> winPlayers)
        {
            gameObject.SetActive(true);

            if(winPlayers.Count == 1)
            {
                int winPlayer = winPlayers[0];
                resultText.text = $"플레이어 {winPlayer + 1} 승리!";
                backgroundImg.color = TTGameView.Instance.GetUIColorOf(winPlayer);
            }
            else
            {
                resultText.text = $"무승부";
                List<Color> winPlayerColors = winPlayers.Select(player => TTGameView.Instance.GetUIColorOf(player)).ToList();
                backgroundImg.color = MixColors(winPlayerColors);
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
            if(colors == null || colors.Count == 0)
            {
                return Color.white;
            }

            Color mixedColor = colors[0];
            for(int i = 1; i < colors.Count; i++)
            {
                mixedColor += colors[i];
            }
            mixedColor /= colors.Count;

            return mixedColor;
        }
    }
}