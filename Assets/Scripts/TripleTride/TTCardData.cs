using UnityEngine;

public enum ECardType
{
    None,
    Primal,
    Dawn,
    Empire,
    Beastmen
}

namespace Ahyeong.TripleTride
{
    [CreateAssetMenu]
    public class TTCardData : ScriptableObject
    {
        public ECardType type;
        public int rankUp;
        public int rankRight;
        public int rankDown;
        public int rankLeft;
    }
}