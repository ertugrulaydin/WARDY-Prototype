using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace WARDY.ObjectPools
{
    public class WingedRockets : MonoBehaviour
    {
        private List<GameObject> wingedBasicRockets = new List<GameObject>();

        private GameObject _wingedBasicRocket;

        public int _amountRockets;


        private void Start()
        {

            _amountRockets = transform.childCount;

            for (int i = 0; i < _amountRockets; i++)
            {

                _wingedBasicRocket = transform.GetChild(i).gameObject;

                wingedBasicRockets.Add(_wingedBasicRocket);

            }


        }

        public GameObject GetWingedBasicRocket(int index)
        {

            return wingedBasicRockets[index];

        }
    }
}

