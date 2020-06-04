namespace Ahyeong.TripleTriad
{
    public class TTBoard
    {
        private TTCard[,] _slots;
        public int Height => _slots.GetUpperBound(0) + 1;
        public int Width => _slots.GetUpperBound(1) + 1;
        public int SlotCount => _slots.Length;

        private TTRuleContext _ruleContext = new TTRuleContext();

        public TTBoard( int boardHeight, int boardWidth, TTRuleContext ruleContext)
        {
            _slots = new TTCard[boardHeight, boardWidth];
            _ruleContext = ruleContext;
        }

        public void PutCard(TTCard card, int indexOfRow, int indexOfColumn)
        {
            if (IsCardExistAt(indexOfRow, indexOfColumn))
            {
                return;
            }

            _slots[indexOfRow, indexOfColumn] = card;
            _ruleContext.ApplyRuleOnMove(this, card.belongPlayerId, indexOfRow, indexOfColumn);
        }

        public bool IsBoardFull()
        {
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    if (!IsCardExistAt(row, col))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool IsCardExistAt(int indexOfRow, int indexOfColumn)
        {
            return _slots[indexOfRow, indexOfColumn] != null;
        }

        public TTCard GetCardAt(int indexOfRow, int indexOfColumn)
        {
            if (IsPositionValid(indexOfRow, indexOfColumn))
            {
                return _slots[indexOfRow, indexOfColumn];
            }
            return null;
        }

        public TTCard GetCardAt(int indexOfRow, int indexOfColumn, Direction direction)
        {
            #region Apply Direction
            switch (direction)
            {
                case Direction.Up:
                    indexOfRow -= 1;
                    break;
                case Direction.Right:
                    indexOfColumn += 1;
                    break;
                case Direction.Down:
                    indexOfRow += 1;
                    break;
                case Direction.Left:
                    indexOfColumn -= 1;
                    break;
            }
            #endregion
            
            return GetCardAt(indexOfRow, indexOfColumn);
        }

        private bool IsPositionValid(int indexOfRow, int indexOfColumn)
        {
            return (indexOfRow >= 0) && (indexOfRow < Height) && (indexOfColumn >= 0) && (indexOfColumn < Width);
        }
    }
}