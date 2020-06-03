using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ahyeong.TripleTride
{
    public class TTBoard
    {
        public TTCard[,] slots;
        public int Width => slots.GetUpperBound(1) + 1;
        public int Height => slots.GetUpperBound(0) + 1;
        public int SlotCount => slots.Length;

        private TTRuleContext _ruleContext = new TTRuleContext();

        public TTBoard(int boardWidth, int boardHeight, TTRuleContext ruleContext)
        {
            slots = new TTCard[boardHeight, boardWidth];
            _ruleContext = ruleContext;
        }

        public void PutCard(TTCard card, int i, int j)
        {
            if(IsCardExistAt(i, j))
            {
                return;
            }

            slots[i, j] = card;
            _ruleContext.ApplyRuleOnMove(this, card.ownPlayer, i, j);
        }

        public void OnTypeAdded()
        {

        }

        public bool IsBoardFull()
        {
            for(int i = 0; i < Height; i++)
            {
                for(int j = 0; j < Width; j++)
                {
                    if(!IsCardExistAt(i, j))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool IsCardExistAt(int i, int j)
        {
            return slots[i, j] != null;
        }

        public TTCard GetCardAt(int index_i, int index_j)
        {
            if (IsPositionValid(index_i, index_j))
            {
                return slots[index_i, index_j];
            }
            return null;
        }

        public TTCard GetCardAt(int index_i, int index_j, EDirection direction)
        {
            #region Apply Direction
            switch (direction)
            {
                case EDirection.Up:
                    index_i -= 1;
                    break;
                case EDirection.Right:
                    index_j += 1;
                    break;
                case EDirection.Down:
                    index_i += 1;
                    break;
                case EDirection.Left:
                    index_j -= 1;
                    break;
            }
            #endregion
            
            return GetCardAt(index_i, index_j);
        }

        public bool IsPositionValid(int index_i, int index_j)
        {
            return (index_i >= 0) && (index_i < Height) && (index_j >= 0) && (index_j < Width);
        }
    }
}