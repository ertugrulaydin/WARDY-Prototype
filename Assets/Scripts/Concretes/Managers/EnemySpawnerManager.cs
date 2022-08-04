using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WARDY.ObjectPools;
using WARDY.Controllers;


namespace WARDY.Managers
{
    public class EnemySpawnerManager : MonoBehaviour
    {
        [SerializeField] private Transform _playerTransform;

        [SerializeField] List<GameObject> _enemies;

        [SerializeField] GameObject _spawnPoints;

        private SpawnPointController _spawnPointController;

        private List<Vector3> _spawnPointsPosition = new List<Vector3>();

        private float _distance = 24f;

        private Vector3 _spawnerPosition = new Vector3(0, 0, 0);

        private int _positionListIndex = 0;

        private Vector3 _nextPosition;

        private Vector3 _enemySpawnPosition;

        private int _enemyCount;

        private GameObject _enemyType;

        private float _offset = 5f;




        void Start()
        {

            for (int i = 0; i < _spawnPoints.transform.childCount; i++)
            {
                _spawnPointsPosition.Add(_spawnPoints.transform.GetChild(i).position);

            }
            _nextPosition = _spawnPointsPosition[_positionListIndex];




        }


        void FixedUpdate()
        {
            SpawnerPosition();

            if (transform.position.x >= _nextPosition.x && _positionListIndex < _spawnPointsPosition.Count)
            {

                _spawnPointController = _spawnPoints.transform.GetChild(_positionListIndex).GetComponent<SpawnPointController>();


                _enemyType = _spawnPointController.EnemyType;
                _enemyCount = _spawnPointController.SpawnedEnemyCount;

                _enemySpawnPosition = _nextPosition;

                SetActiveGameObject(_enemyType);


                _positionListIndex++;

                _nextPosition = _spawnPointsPosition[_positionListIndex];



            }
        }

        private void SpawnerPosition()
        {

            _spawnerPosition = new Vector3(_playerTransform.position.x + _distance, 0, 0);
            transform.position = _spawnerPosition;

        }

        private void SetActiveGameObject(GameObject enemyType)
        {
            Debug.Log("spawn metodunda");
            for (int i = 0; i < _enemyCount; i++)
            {
                if (_enemyType.name == "KevA")
                {

                    GameObject kevA = KevAPool.instance.GetPooledKevA();

                    kevA.transform.position = _enemySpawnPosition;

                    kevA.gameObject.SetActive(true);

                }
                if (_enemyType.name == "KevB")
                {

                    GameObject kevB = KevBPool.instance.GetPooledKevA();

                    kevB.transform.position = _enemySpawnPosition;

                    kevB.gameObject.SetActive(true);

                }

                _enemySpawnPosition.x += _offset;

            }


        }
    }
}

