using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MapGeneration : MonoBehaviour
{
    [SerializeField] private MapGenerationSettings mapSettings;

    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private GameObject floorPrefab;
    [SerializeField] private Transform playerParent;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject playerMinionPrefab;
    [SerializeField] private Transform enemyParent;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject enemyMinionPrefab;
    
    [SerializeField] private TeamUI playerUI;
    [SerializeField] private TeamUI enemyUI;

    [SerializeField] private ProfitSpawner profitSpawner;
    
    

    private GameObject _player;
    
    
    private void Start()
    {
        SpawnMap();

        SpawnPlayer();

        SpawnPlayerMinions();
        
        SpawnEnemy();

        SpawnEnemyMinions();
        
        SpawnProfitObjects();

        PlaceCamera();
    }

    private void SpawnMap()
    {
        SpawnFloor();

        SpawnWalls();
    }

    private void SpawnFloor()
    {
        GameObject floor = Instantiate(floorPrefab, Vector3.zero, Quaternion.identity, transform);
        floor.transform.localScale = new Vector3(mapSettings.width / 10, 1f, mapSettings.length / 10);
        floor.name = "Floor";
    }

    private void SpawnWalls()
    {
        GameObject emptyGo = new GameObject();
        GameObject wallsContainer = Instantiate(emptyGo, transform);
        wallsContainer.name = "Walls";

        float wallYPos = 0;

        GameObject wall1 = Instantiate(wallPrefab,
            new Vector3((mapSettings.width + mapSettings.wallWidth) / 2, wallYPos, 0), Quaternion.identity,
            wallsContainer.transform);
        wall1.transform.localScale = new Vector3(mapSettings.wallWidth, mapSettings.wallHeight, mapSettings.length + mapSettings.wallWidth * 2);
        wall1.name = "Wall1";

        GameObject wall2 = Instantiate(wallPrefab,
            new Vector3(-(mapSettings.width + mapSettings.wallWidth) / 2, wallYPos, 0), Quaternion.identity,
            wallsContainer.transform);
        wall2.transform.localScale = new Vector3(mapSettings.wallWidth, mapSettings.wallHeight, mapSettings.length + mapSettings.wallWidth * 2);
        wall2.name = "Wall2";

        GameObject wall3 = Instantiate(wallPrefab,
            new Vector3(0, wallYPos, (mapSettings.length + mapSettings.wallWidth) / 2), Quaternion.identity,
            wallsContainer.transform);
        wall3.transform.localScale = new Vector3(mapSettings.width, mapSettings.wallHeight, mapSettings.wallWidth);
        wall3.name = "Wall3";

        GameObject wall4 = Instantiate(wallPrefab,
            new Vector3(0, wallYPos, -(mapSettings.length + mapSettings.wallWidth) / 2), Quaternion.identity,
            wallsContainer.transform);
        wall4.transform.localScale = new Vector3(mapSettings.width, mapSettings.wallHeight, mapSettings.wallWidth);
        wall4.name = "Wall4";
    }
    
    private void SpawnPlayer()
    {
        _player = Instantiate(playerPrefab, new Vector3(0, 0.5f, 0), Quaternion.identity, playerParent);
        var playerStats = _player.GetComponent<Stats>();
        playerUI.Attach(playerStats);
    }

    private void SpawnPlayerMinions()
    {

        GameObject parent = Instantiate(new GameObject(), playerParent);
        parent.name = "Ally Minions";
        for (int i = 0; i < mapSettings.playerMinions; i++)
        {
            GameObject minion = Instantiate(playerMinionPrefab, mapSettings.RandomPosition(), Quaternion.identity,
                parent.transform);
            minion.name = $"Minion {i}";
        }
    }
    
    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, new Vector3(3, 0.5f, -5), Quaternion.identity);
        var playerStats = _player.GetComponent<Stats>();
        enemyUI.Attach(playerStats);
    }
    
    private void SpawnEnemyMinions()
    {

        GameObject parent = Instantiate(new GameObject(), enemyParent);
        parent.name = "Enemy Minions";
        for (int i = 0; i < mapSettings.playerMinions; i++)
        {
            GameObject minion = Instantiate(enemyMinionPrefab, mapSettings.RandomPosition(), Quaternion.identity,
                parent.transform);
            minion.name = $"Minion {i}";
        }
    }


    private void SpawnProfitObjects()
    {
        profitSpawner.MapGenerationSettings =  mapSettings;
        for (int i = 0; i < mapSettings.profitObjects; i++)
        {
            profitSpawner.SpawnObject();
        }
    }

    private void PlaceCamera()
    {
        Camera mainCamera = Camera.main;
        CameraController camController = mainCamera.gameObject.GetComponent<CameraController>();
        camController.Player = _player.transform;
    }
}
