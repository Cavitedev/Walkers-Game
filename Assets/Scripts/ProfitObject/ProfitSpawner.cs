using UnityEngine;

public class ProfitSpawner : MonoBehaviour
{
    [SerializeField] private GameObject profitObjectPrefab;
    public MapGenerationSettings MapGenerationSettings { get; set; }

    public void SpawnObject()
    {
        GameObject profitObject = Instantiate(profitObjectPrefab, MapGenerationSettings.RandomPosition(),
            Quaternion.identity, transform);
        var respawnProfit = profitObject.GetComponent<RespawnProfit>();
        respawnProfit.ProfitSpawner = this;
    }

    public void MoveProfitObject(Transform profitObject)
    {
        profitObject.position = MapGenerationSettings.RandomPosition();
    }
}