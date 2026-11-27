using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [Header("Map Settings")]
    public GameObject groundPrefab;
    public GameObject roadPrefab;

    public int mapWidth = 50;
    public int mapHeight = 50;

    [Header("Road Settings")]
    public int roadWidth = 1;
    public int centralAreaSize = 1;

    [Header("Environment")]
    public GameObject housePrefab;
    public GameObject treePrefab;

    void Start()
    {
        GenerateMap();
        GenerateEnvironment();
    }

    void GenerateMap()
    {
        int centerX = mapWidth / 2;
        int centerY = mapHeight / 2;

        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                bool isRoad =
                    Mathf.Abs(x - centerX) < roadWidth ||
                    Mathf.Abs(y - centerY) < roadWidth;

                bool isCentralArea =
                    Mathf.Abs(x - centerX) < centralAreaSize / 2 &&
                    Mathf.Abs(y - centerY) < centralAreaSize / 2;

                GameObject prefab = isRoad && !isCentralArea
                    ? roadPrefab
                    : groundPrefab;

                Vector3 position = GridToWorld(x, y);

                Instantiate(
                    prefab,
                    position,
                    Quaternion.identity,
                    transform
                );
            }
        }
    }

    void GenerateEnvironment()
    {
        // Размещаем разрушенные дома
        SpawnObject(housePrefab, 6, 6);
        SpawnObject(housePrefab, 14, 6);
        SpawnObject(housePrefab, 6, 14);
        SpawnObject(housePrefab, 14, 14);

        // Размещаем деревья
        SpawnObject(treePrefab, 3, 3);
        SpawnObject(treePrefab, 16, 3);
        SpawnObject(treePrefab, 3, 16);
        SpawnObject(treePrefab, 16, 16);

        SpawnObject(treePrefab, 4, 5);
        SpawnObject(treePrefab, 15, 5);
        SpawnObject(treePrefab, 5, 15);
        SpawnObject(treePrefab, 15, 14);
    }

    void SpawnObject(GameObject prefab, int x, int y)
    {
        if (prefab == null)
            return;

        Instantiate(
            prefab,
            GridToWorld(x, y),
            Quaternion.identity,
            transform
        );
    }

    Vector3 GridToWorld(int x, int y)
    {
        return new Vector3(
            x - y,
            (x + y) * 0.5f,
            0
        );
    }
}
