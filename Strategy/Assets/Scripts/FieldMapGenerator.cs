using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class FieldMapGenerator : MonoBehaviour
{
    #region Singleton
    private static FieldMapGenerator instance;
    public static FieldMapGenerator GetInstance()
    {
        if (instance == null)
        {
            instance = new FieldMapGenerator();
        }


        return instance;
    }
    #endregion


    private GameObject ParentGameobject;
    /// <summary>
    /// Prefabs for cell generation
    /// </summary>
    private List<GameObject> CellPrefabs = new List<GameObject>();
    /// <summary>
    /// Prefabs for generating obstacles
    /// </summary>
    private List<GameObject> ObstaclePrefabs = new List<GameObject>();
    /// <summary>
    /// Prefab for generating backend obstacles
    /// </summary>
    private List<GameObject> BackendObstaclePrefabs = new List<GameObject>();

    private FieldMapGenerator()
    {
        LoadResources();
    }
    #region Resource Loader
    private void LoadResources()
    {
        string PathFolderCellPrefabs = "Prefabs/Map/Cells";
        string PathFolderObstaclePrefabs = "Prefabs/Map/Obstacles";
        string PathFolderBackendObstaclePrefabs = "Prefabs/Map/BackendObstaclePrefabs";

        ParentGameobject = GameObject.Find("Playing field");

        GameObject[] Cells = Resources.LoadAll<GameObject>(PathFolderCellPrefabs);
        GameObject[] Obstacles = Resources.LoadAll<GameObject>(PathFolderObstaclePrefabs);
        GameObject[] BackendObstacles = Resources.LoadAll<GameObject>(PathFolderBackendObstaclePrefabs);

        foreach (var cell in Cells)
        {
            CellPrefabs.Add(cell);
        }
        foreach(var obstacle in Obstacles)
        {
            ObstaclePrefabs.Add(obstacle);
        }
        foreach (var backendObstacle in BackendObstacles)
        {
            BackendObstaclePrefabs.Add(backendObstacle);
        }
    }
    #endregion
    #region Map generation methods
    public void MapGenerator(List<GameObject> Cells,out List<GameObject> FieldCells,List<GameObject> Obstacles,out List<GameObject> FieldObstacles,List<GameObject> BackendObstacles,
        out List<GameObject> FieldBackendObstacles, RoundManager RoundManager)
    {
        List<GameObject> CreatedCellPool = new List<GameObject>();
        List<GameObject> CreatedObstaclePool = new List<GameObject>();
        List<GameObject> CreatedBackendObstaclePool = new List<GameObject>();

        int _randomPrefab;
        int _randomRotation;
        List<Vector3> _deegresOfRotation = new List<Vector3>(7)
        {
        new Vector3(-90, 0, 0),
        new Vector3(-90, 60, 0),
        new Vector3(-90, 120, 0),
        new Vector3(-90, 180, 0),
        new Vector3(-90, 240, 0),
        new Vector3(-90, 300, 0),
        new Vector3(-90, 360, 0)
        };
        foreach (var cell in Cells)
        {
            _randomPrefab = Random.Range(0, CellPrefabs.Count - 1);
            _randomRotation = Random.Range(0, _deegresOfRotation.Count);

            GameObject Cell = Instantiate(CellPrefabs[_randomPrefab], cell.transform.position, Quaternion.Euler(_deegresOfRotation[_randomRotation]), ParentGameobject.transform);
            Cell.AddComponent<Cell>();
            Destroy(cell);
            CreatedCellPool.Add(Cell);
        }
        foreach (var obstacle in Obstacles)
        {
            _randomPrefab = Random.Range(0, ObstaclePrefabs.Count);

            GameObject Obstacle = Instantiate(ObstaclePrefabs[_randomPrefab], obstacle.transform.position, Quaternion.Euler(obstacle.transform.rotation.eulerAngles), ParentGameobject.transform);
            Destroy(obstacle);
            CreatedObstaclePool.Add(Obstacle);
        }
        foreach(var backendObstacle in BackendObstacles)
        {
            _randomPrefab = Random.Range(0, BackendObstaclePrefabs.Count);

            GameObject BackendObstacle = Instantiate(BackendObstaclePrefabs[_randomPrefab], backendObstacle.transform.position, Quaternion.Euler(backendObstacle.transform.rotation.eulerAngles), ParentGameobject.transform);
            Destroy(backendObstacle);
            CreatedBackendObstaclePool.Add(BackendObstacle);
        }
        FieldCells = CreatedCellPool;
        FieldObstacles = CreatedObstaclePool;
        FieldBackendObstacles = CreatedBackendObstaclePool;

        for (int i = 0; i <= RoundManager.GetFirstPlayerUnitsPosition.Count - 1; i++)
        {
            foreach (var cell in FieldCells)
            {
                if (cell.transform.position == RoundManager.GetFirstPlayerUnitsPosition[i].transform.position)
                {
                    RoundManager.GetFirstPlayerUnitsPosition[i] = cell;
                }
                else if (cell.transform.position == RoundManager.GetSecondPlayerUnitsPosition[i].transform.position)
                {
                    RoundManager.GetSecondPlayerUnitsPosition[i] = cell;
                }
            }
        }
    }
    #endregion
}
