using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using WARDY.Abstracts.Controllers;

namespace WARDY.ObjectPools
{
    public class EnemyBasicBulletPool : MonoBehaviour
    {
        //public static EnemyBasicBulletPool _instance;

        private List<GameObject> basicBullets = new List<GameObject>();



        [SerializeField] int _amountToPool;
        [SerializeField] GameObject enemyBasicBulletPrefab;

        //[SerializeField] GameObject parentEnemyBasicBullets;
        GameObject returnedGameObject;

        float _fireRate;


        /* 
                private void Awake()
                {
                    if (_instance == null)
                    {
                        _instance = this;
                    }
                }
         */
        private void Start()
        {
            for (int i = 0; i < _amountToPool; i++)
            {
                //StartCoroutine("InstantiateBullets");
                GameObject _basicBullet = Instantiate(enemyBasicBulletPrefab);

                //_basicBullet.transform.parent = null;
                _basicBullet.transform.parent = GameObject.Find("EnemyBulletPool").transform;

                basicBullets.Add(_basicBullet);

            }

        }

        public GameObject GetPooledObject(float fireRate)
        {
            _fireRate = fireRate;

            for (int i = 0; i < basicBullets.Count; i++)
            {
                if (!basicBullets[i].activeInHierarchy)
                {


                    StartCoroutine("ReturnBulletWithCoroutine", basicBullets[i]);
                    return returnedGameObject;

                    //return basicBullets[i];

                }
            }

            return null;
        }
        /* 
                IEnumerator InstantiateBullets()
                {

                    yield return new WaitForSeconds(_fireRate);

                } */

        IEnumerator ReturnBulletWithCoroutine(GameObject bullet)
        {

            yield return new WaitForSeconds(_fireRate);
            returnedGameObject = bullet;
        }


    }

}