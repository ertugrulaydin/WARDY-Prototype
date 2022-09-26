using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WARDY.Controllers.EnemyControllers.Kevs;

namespace WARDY.ObjectPools
{
    public class KevBPool : MonoBehaviour
    {
        public static KevBPool instance;

        private List<GameObject> _kevsB = new List<GameObject>();




        private void Awake()
        {

            if (instance == null)
            {

                instance = this;

            }
        }

        private void Start()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                _kevsB.Add(transform.GetChild(i).gameObject);

            }
        }




        public GameObject GetPooledKevB()
        {

            for (int i = 0; i < _kevsB.Count; i++)
            {
                if (!_kevsB[i].activeInHierarchy)
                {
                    _kevsB[i].gameObject.GetComponent<KevB>().DefaultHealth();
                    return _kevsB[i];
                }
            }

            return null;

        }




    }
}


