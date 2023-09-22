using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace DarkestGym.FieldGenerator
{
    public class FieldGenerator : MonoBehaviour
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private GameObject _gameMap;
        private List<Vector3> _deegresOfRotation = new List<Vector3>(7)
        {
        new Vector3(-90, 0, 0),
        new Vector3(-90, 60, 0),
        new Vector3(-90, 120, 0),
        new Vector3(-90, 180, 0),
        new Vector3(-90, 240, 0),
        new Vector3(-90, 300, 0),
        new Vector3(-90, 360, 0)
        };

        private void Start()
        {
            MapGenerator();
        }
        #region MapGenerator
        private void MapGenerator()
        {
            int _randomPrefab;
            int _randomRotation;
            for (int i = 0; i < _gameManager._cells.Count; i++)
            {
                _randomPrefab = TakeBuildRandomiserCells();
                _randomRotation = Random.Range(0, _deegresOfRotation.Count);

                GameObject Cell = Instantiate(_gameManager._prefabCell[_randomPrefab], _gameManager._cells[i].position, Quaternion.Euler(_deegresOfRotation[_randomRotation]), _gameMap.transform);
                Destroy(_gameManager._cells[i].gameObject);
                _gameManager._cells[i] = Cell.transform;
                _gameManager._cells[i].gameObject.GetComponent<Cell>()._gameManager = gameObject.GetComponent<GameManager>();
            }

            for (int j = 0; j < _gameManager._waterObstaclesCells.Count; j++)
            {
                _randomPrefab = TakeBuildRandomiserObstacles();
                _randomRotation = Random.Range(0, _deegresOfRotation.Count);
                if (_randomPrefab != 3)
                { 
                    GameObject BackGroundObstacle = Instantiate(_gameManager._waterpObstaclesPrefab[_randomPrefab].gameObject, _gameManager._waterObstaclesCells[j].position,
                        Quaternion.Euler(_deegresOfRotation[_randomRotation]), _gameMap.transform);
                    Destroy(_gameManager._waterObstaclesCells[j].gameObject);

                    _gameManager._waterObstaclesCells[j] = BackGroundObstacle.transform;
                }
                else
                {

                }
            }

            for (int k = 0; k < _gameManager._obstacles.Count; k++)
            {
                _randomPrefab = TakeBuildRandomiserObstacles();
                _randomRotation = Random.Range(0, _deegresOfRotation.Count);
                if (_randomPrefab != 3)
                {
                    GameObject Obstacles = Instantiate(_gameManager._prefabObstacles[_randomPrefab], _gameManager._obstacles[k].position,
                        Quaternion.Euler(_deegresOfRotation[_randomRotation]), _gameMap.transform);
                    Destroy(_gameManager._obstacles[k].gameObject);

                    _gameManager._obstacles[k] = Obstacles.transform;
                }
            }
        }
        private int TakeBuildRandomiserCells()
        {
            int _randomNum = Random.Range(0, 100);
            if (_randomNum <= 45)
            {
                return 0;
            }else if (_randomNum >= 75 )
            {
                return 1;
            }
            else
            {
                _randomNum = Random.Range(0, 8);
                return _randomNum;
            }
        }
        private int TakeBuildRandomiserObstacles()
        {
            int _randomNum = Random.Range(0, 100);
            if (_randomNum <= 10)
            {
                return 0;
            }
            else if (_randomNum > 50 && _randomNum <= 60)
            {
                return 1;
            }
            else if(_randomNum > 90 && _randomNum <= 100)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }
        #endregion
    }
}