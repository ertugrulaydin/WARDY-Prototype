using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WARDY.Controllers.EnemyControllers.Kevs;

namespace WARDY.ObjectPools
{
    public class KevAPool : MonoBehaviour
    {
        public static KevAPool instance;

        private List<GameObject> _kevsA = new List<GameObject>();




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
                _kevsA.Add(transform.GetChild(i).gameObject);

            }
        }




        public GameObject GetPooledKevA()
        {

            for (int i = 0; i < _kevsA.Count; i++)
            {
                if (!_kevsA[i].activeInHierarchy)
                {
                    _kevsA[i].gameObject.GetComponent<KevA>().DefaultHealth();
                    return _kevsA[i];
                }
            }

            return null;

        }




    }
}

