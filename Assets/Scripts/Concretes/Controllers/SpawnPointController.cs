using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WARDY.Controllers
{
    public class SpawnPointController : MonoBehaviour
    {


        #region SerializeFields

        [SerializeField] private GameObject _enemyType;

        //[SerializeField] private int _spawnedEnemyCount;

        #endregion

        #region Privates

        private Vector3 _spawnPointPosition;

        #endregion

        #region Properties

        public GameObject EnemyType => _enemyType;

        //public int SpawnedEnemyCount => _spawnedEnemyCount;

        public Vector3 SpawnPointPosition => _spawnPointPosition;

        #endregion



        private void Start()
        {

            _spawnPointPosition = transform.position;

        }




    }

}

