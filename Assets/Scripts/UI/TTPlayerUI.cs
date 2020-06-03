using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ahyeong.TripleTride.UI
{
    public class TTPlayerUI : MonoBehaviour
    {
        public TTCardUI playerCardUIPrefab;
        public Transform cardParent;
        public GameObject moveBlocker;
        public Color cardColor = Color.white;
        public Color uiColor = Color.white;
        private TTCardUI[] cardUIs;

        public void InitializeUI(TTPlayer player)
        {
            int cardCount = player.playerHand.Count;
            cardUIs = new TTCardUI[cardCount];
            
            for (int i = 0; i < cardCount; i++)
            {
                cardUIs[i] = Instantiate(playerCardUIPrefab, cardParent);
                cardUIs[i].UpdateUI(player.playerHand[i]);
            }
        }

        public void UpdateUI(TTPlayer player, bool canMove)
        {
            int cardCount = player.playerHand.Count;
            for (int i = 0; i < cardCount; i++)
            {
                cardUIs[i].UpdateUI(player.playerHand[i]);
            }

            moveBlocker.SetActive(!canMove);
        }
    }
}