using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace WARDY.Managers
{
    public class EnemyHealthUIManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text _enemyHealthUI;
        private int _enemyHealth = 100;


        private void Start()
        {
            _enemyHealthUI.text = _enemyHealth.ToString();
            EventManager.EnemyGetHit += SetEnemyHealthUI;

        }

        private void SetEnemyHealthUI(float _f)
        {
            _enemyHealth -= 30;
            _enemyHealthUI.text = _enemyHealth.ToString();
        }
    }
}

