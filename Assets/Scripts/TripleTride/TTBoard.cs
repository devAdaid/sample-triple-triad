namespace Ahyeong.TripleTride
{
    public class TTBoard
    {
        private TTCard[,] _slots;
        public int Width => _slots.GetUpperBound(1) + 1;
        public int Height => _slots.GetUpperBound(0) + 1;
        public int SlotCount => _slots.Length;

        private TTRuleContext _ruleContext = new TTRuleContext();

        public TTBoard( int boardHeight, int boardWidth, TTRuleContext ruleContext)
        {
            _slots = new TTCard[boardHeight, boardWidth];
            _ruleContext = ruleContext;
        }

        public void PutCard(TTCard card, int index_i, int index_j)
        {
            if (IsCardExistAt(index_i, index_j))
            {
                return;
            }

            _slots[index_i, index_j] = card;
            _ruleContext.ApplyRuleOnMove(this, card.belongPlayerId, index_i, index_j);
        }

        public bool IsBoardFull()
        {
            for(int i = 0; i < Height; i++)
            {
                for(int j = 0; j < Width; j++)
                {
                    if (!IsCardExistAt(i, j))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool IsCardExistAt(int i, int j)
        {
            return _slots[i, j] != null;
        }

        public TTCard GetCardAt(int index_i, int index_j)
        {
            if (IsPositionValid(index_i, index_j))
            {
                return _slots[index_i, index_j];
            }
            return null;
        }

        public TTCard GetCardAt(int index_i, int index_j, Direction direction)
        {
            #region Apply Direction
            switch (direction)
            {
                case Direction.Up:
                    index_i -= 1;
                    break;
                case Direction.Right:
                    index_j += 1;
                    break;
                case Direction.Down:
                    index_i += 1;
                    break;
                case Direction.Left:
                    index_j -= 1;
                    break;
            }
            #endregion
            
            return GetCardAt(index_i, index_j);
        }

        private bool IsPositionValid(int index_i, int index_j)
        {
            return (index_i >= 0) && (index_i < Height) && (index_j >= 0) && (index_j < Width);
        }
    }
}