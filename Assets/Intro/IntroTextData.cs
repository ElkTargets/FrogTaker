using UnityEngine;

namespace Introduction
{
    [CreateAssetMenu(fileName = "Intro Data", menuName = "Intro")]
    public class IntroTextData : ScriptableObject
    {
        public string characterName;
        public Sprite sprite;
        public string text;
        public AudioClip audioClip;
        public IntroTextData nextData;
    }
}
