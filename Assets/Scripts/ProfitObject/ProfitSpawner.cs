

    using UnityEngine;
    using UnityEngine.Serialization;

    public class ProfitSpawner : MonoBehaviour
    {

         [SerializeField] private GameObject profitObjectPrefab;
         private float width;
         private float length;


         public void SetMap(MapGenerationSettings mapSettings)
         {
             width = (mapSettings.width / 2) - 1;
             length = (mapSettings.length / 2) - 1;
             
         }
         
        public void SpawnObject()
        {
            GameObject profitObject = Instantiate(profitObjectPrefab, RandomPosition(), Quaternion.identity, transform);
            var respawnProfit = profitObject.GetComponent<RespawnProfit>();
            respawnProfit.ProfitSpawner = this;
        }

        public void MoveProfitObject(Transform profitObject)
        {
            profitObject.position = RandomPosition();
        }

        private Vector3 RandomPosition()
        {
            return new Vector3(Random.Range(-width, width), 0.5f, Random.Range(-length, length));
        }
        

    }
