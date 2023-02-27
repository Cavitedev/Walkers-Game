

    using UnityEngine;

    [CreateAssetMenu(fileName = "MapGeneration", menuName = "ScriptableObjects/MapGeneration", order = 1)]
    public class MapGenerationSettings: ScriptableObject
    {
        public float width = 10f;
        public float length = 20f;
        public float wallHeight = 2f;
        public float wallWidth = 0.5f;

    }
