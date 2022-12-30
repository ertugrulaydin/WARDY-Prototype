using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WARDY.Managers
{
    public class SurpriseBox : MonoBehaviour
    {

        GameManager _gameManager;

        int _currentLevel;

        void Start()
        {
            _currentLevel = GameObject.Find("[GameManager]").GetComponent<GameManager>().GetCurrentLevelIndex();


        }

        void Update()
        {

        }
    }
}

