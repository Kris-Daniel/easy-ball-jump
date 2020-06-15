using UnityEngine;

namespace ScriptableObjects {
    [CreateAssetMenu(fileName = "Theme", menuName = "Game Theme", order = 0)]
    public class Theme : ScriptableObject {
        public Color BackgroundColor;
        public Color BallColor;
    }
}