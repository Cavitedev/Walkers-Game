

    using UnityEngine;

    [CreateAssetMenu(fileName = "MapGeneration", menuName = "ScriptableObjects/MapGeneration", order = 1)]
    public class MapGenerationSettings: ScriptableObject
    {
        public float width = 10f;
        public float length = 20f;
        public float wallHeight = 2f;
        public float wallWidth = 0.5f;
        public int profitObjects = 5;

        public int playerMinions = 3;
        public int enemyMinions = 3;
        
        public float minWidthSpawn() => width / 2 - 1;
        public float minLengthSpawn() => length / 2 - 1;
        
        public Vector3 RandomPosition()
        {

            return new Vector3(Random.Range(-minWidthSpawn(), minWidthSpawn()), 0.5f, Random.Range(-minLengthSpawn(), minLengthSpawn()));
        }


    }
