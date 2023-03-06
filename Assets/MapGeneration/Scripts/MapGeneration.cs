using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{

    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private GameObject floorPrefab;
    [SerializeField] private MapGenerationSettings mapSettings;
    
    
    private void Start()
    {
        BuildMap();

        PlaceCamera();
    }

    private void BuildMap()
    {
        BuildFloor();

        BuildWalls();
    }

    private void BuildFloor()
    {
        GameObject floor = Instantiate(floorPrefab, Vector3.zero, Quaternion.identity, transform);
        floor.transform.localScale = new Vector3(mapSettings.width / 10, 1f, mapSettings.length / 10);
        floor.name = "Floor";
    }

    private void BuildWalls()
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

    private void PlaceCamera()
    {
        Camera mainCamera = Camera.main;
        mainCamera.transform.position = new Vector3(0, mapSettings.width / 2 + 2f, -mapSettings.length / 2);
        mainCamera.transform.rotation =
            Quaternion.LookRotation(new Vector3(0,0, -2) - mainCamera.transform.position, Vector3.up);
    }
}
