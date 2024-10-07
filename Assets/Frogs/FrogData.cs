using UnityEngine;

namespace Frogs
{
    [CreateAssetMenu(fileName = "Frogs Data", menuName = "Frogs")]
    public class FrogData : ScriptableObject
    {
        public Sprite frogSprite;
        public string frogName;
        [TextArea(3,10)]
        public string frogDescription;
    }
}
