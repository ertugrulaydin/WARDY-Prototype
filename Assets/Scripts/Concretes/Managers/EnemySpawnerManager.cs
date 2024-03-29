using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WARDY.ObjectPools;
using WARDY.Controllers;
using WARDY.Abstracts.Controllers;

namespace WARDY.Managers
{
    public class EnemySpawnerManager : MonoBehaviour
    {
        [SerializeField] private Transform _playerTransform;

        //[SerializeField] List<GameObject> _enemies;

        [SerializeField] GameObject _spawnPoints;

        private SpawnPointController _spawnPointController;

        private List<Vector3> _spawnPointsPosition = new List<Vector3>();

        private float _distance = 24f;

        private Vector3 _spawnerPosition = new Vector3(0, 0, 0);

        private int _positionListIndex = 0;

        private Vector3 _nextPosition;

        private Vector3 _enemySpawnPosition;

        private GameObject _enemyType;

        private GameObject kev;







        void Start()
        {

            for (int i = 0; i < _spawnPoints.transform.childCount; i++)
            {

                _spawnPointsPosition.Add(_spawnPoints.transform.GetChild(i).position);

            }

            StartCoroutine("EnemySpawn");

        }

        /*
                void Update()
                {

                    SpawnerPosition();

                    StartCoroutine("EnemySpawn");

                }

        */
        IEnumerator EnemySpawn()
        {


            while (true)
            {

                SpawnerPosition();

                if (_positionListIndex < _spawnPointsPosition.Count)
                {

                    if ((int)transform.position.x >= (int)_spawnPointsPosition[_positionListIndex].x)
                    {

                        GetSpawnPointControllerValues();

                        _nextPosition = _spawnPointsPosition[_positionListIndex];

                        _enemySpawnPosition = _nextPosition;

                        SetActiveGameObject(_enemyType);

                        _positionListIndex++;

                    }

                }

                yield return new WaitForSeconds(2f);
            }

        }

        private void SpawnerPosition()
        {

            _spawnerPosition = new Vector3(_playerTransform.position.x + _distance, 0, 0);

            transform.position = _spawnerPosition;

        }

        private void SetActiveGameObject(GameObject enemyType)
        {

            if (_enemyType.name == "KevA")
            {

                kev = KevAPool.instance.GetPooledKevA();

            }
            else if (_enemyType.name == "KevB")
            {

                kev = KevBPool.instance.GetPooledKevB();

            }

            kev.gameObject.SetActive(true);

            kev.transform.position = _enemySpawnPosition;

            kev.gameObject.GetComponent<EnemyController>().SetDefaultVariables();

        }

        private void GetSpawnPointControllerValues()
        {

            _spawnPointController = _spawnPoints.transform.GetChild(_positionListIndex).GetComponent<SpawnPointController>();

            _enemyType = _spawnPointController.EnemyType;

        }
    }
}

