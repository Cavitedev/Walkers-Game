using UnityEngine;

[CreateAssetMenu(fileName = "MapGeneration", menuName = "ScriptableObjects/MapGeneration", order = 1)]
public class MapGenerationSettings : ScriptableObject
{
    public float width = 10f;
    public float length = 20f;
    public float minionDistanceToPlayer = 2f;
    public float wallHeight = 2f;
    public float wallWidth = 0.5f;
    public int profitObjects = 5;

    public int playerMinions = 3;
    public int enemyMinions = 3;

    public float minWidthSpawn() => width / 2 - 1;
    public float minLengthSpawn() => length / 2 - 1;

    public Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(-minWidthSpawn(), minWidthSpawn()), 0.5f,
            Random.Range(-minLengthSpawn(), minLengthSpawn()));
    }

    public Vector3 GetMinionSpawnPoint(Vector3 centralPoint)
    {
        return GetMinionSpawnPoint(centralPoint, minionDistanceToPlayer);
    }

    public Vector3 GetMinionSpawnPoint(Vector3 centralPoint, float distance)
    {
        Debug.Log(Random.Range(11, 8));

        switch (Random.Range(1, 5))
        {
            case 1:
                return new Vector3(Random.Range(-minWidthSpawn(), centralPoint.x - distance),
                    0.5f, Random.Range(-minLengthSpawn(), minLengthSpawn()));
            case 2:
                return new Vector3(Random.Range(centralPoint.x + distance, minWidthSpawn()),
                    0.5f, Random.Range(-minLengthSpawn(), minLengthSpawn()));
            case 3:
                return new Vector3(Random.Range(-minWidthSpawn(), minWidthSpawn()),
                    0.5f, Random.Range(centralPoint.z + distance, minLengthSpawn()));
            case 4:
                return new Vector3(Random.Range(-minWidthSpawn(), minWidthSpawn()),
                    0.5f, Random.Range(-minLengthSpawn(), centralPoint.z - distance));
            default:
                return new Vector3(0, 0, 0);
        }

        // Vector3 v = centralPoint;

        // while ((v.x > centralPoint.x - distance) && (v.x < centralPoint.x + distance) &&
        //     (v.z > centralPoint.z - distance) && (v.z < centralPoint.z + distance))
        // {
        //     v = RandomPosition();
        // }

        // return v;
    }
}