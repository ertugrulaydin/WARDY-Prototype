using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using WARDY.Abstracts.Controllers;

namespace WARDY.ObjectPools
{
    public class EnemyBasicBulletPool : MonoBehaviour
    {

        private List<GameObject> basicBullets = new List<GameObject>();

        [SerializeField] int _amountToPool;

        [SerializeField] GameObject enemyBasicBulletPrefab;

        private void Start()
        {
            for (int i = 0; i < _amountToPool; i++)
            {

                GameObject _basicBullet = Instantiate(enemyBasicBulletPrefab);

                _basicBullet.transform.parent = GameObject.Find("EnemyBulletPool").transform;

                basicBullets.Add(_basicBullet);

            }

        }

        public GameObject GetPooledObject()
        {

            for (int i = 0; i < basicBullets.Count; i++)
            {
                if (!basicBullets[i].activeInHierarchy)
                {

                    return basicBullets[i];

                }
            }

            return null;
        }


    }

}
