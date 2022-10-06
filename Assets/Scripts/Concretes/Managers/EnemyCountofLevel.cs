using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WARDY.Managers
{
    public class EnemyCountofLevel : MonoBehaviour
    {

        #region Private Field

        int _totalEnemyCount = 0;

        //int _enemySpawnedCount = 0;

        int _remainingEnemyCount = 0;

        GameObject _spawnPointsGameObject;

        #endregion

        #region Properties
        public int EnemyCount => _totalEnemyCount;

        #endregion
        private void Start()
        {


            _spawnPointsGameObject = this.transform.Find("SpawnPoints").gameObject;
            _totalEnemyCount = _spawnPointsGameObject.transform.childCount;

            _remainingEnemyCount = _totalEnemyCount;

        }

        private void Update()
        {

            if (_remainingEnemyCount == 0)
            {
                EventManager.OnBossActionStarted();
            }

            // Debug.Log(_remainingEnemyCount);


        }

        /*
                private void EnemySpawned()
                {
                    _enemySpawnedCount += 1;
                    Debug.Log(_enemySpawnedCount);
                }
        */

        private void EnemyKilled(GameObject obj)
        {
            _remainingEnemyCount -= 1;
        }

        private void EnemyKilledByWall()
        {
            _remainingEnemyCount -= 1;
        }



        private void OnEnable()
        {
            //EventManager.EnemySpawned += EnemySpawned;
            EventManager.EnemyDestroyed += EnemyKilled;
            EventManager.EnemyDestroyedByWall += EnemyKilledByWall;
        }




        private void OnDisable()
        {
            //EventManager.EnemySpawned -= EnemySpawned;
            EventManager.EnemyDestroyed -= EnemyKilled;
            EventManager.EnemyDestroyedByWall -= EnemyKilledByWall;
        }


    }
}

