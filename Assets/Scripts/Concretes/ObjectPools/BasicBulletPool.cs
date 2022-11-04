using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using WARDY.Controllers;


namespace WARDY.ObjectPools
{
    public class BasicBulletPool : MonoBehaviour
    {
        public static BasicBulletPool _instance;

        private List<GameObject> basicBullets = new List<GameObject>();

        [SerializeField] int _amountToPool;
        [SerializeField] GameObject basicBulletPrefab;
        GameObject returnedGameObject;



        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
        }

        private void Start()
        {
            for (int i = 0; i < _amountToPool; i++)
            {
                GameObject _basicBullet = Instantiate(basicBulletPrefab);

                _basicBullet.transform.parent = transform;

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

                    //StartCoroutine("ReturnBulletWithCoroutine", basicBullets[i]);
                    //return returnedGameObject;
                }
            }

            return null;
        }

        IEnumerator ReturnBulletWithCoroutine(GameObject bullet)
        {
            yield return new WaitForSeconds(0.125f);
            returnedGameObject = bullet;
        }


    }

}
