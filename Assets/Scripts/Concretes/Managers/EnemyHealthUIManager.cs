using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using WARDY.Abstracts.Controllers;


namespace WARDY.Managers
{
    public class EnemyHealthUIManager
    {
        private TMP_Text enemyHealthUI;

        EnemyController _enemyController;
        private float _enemyHealth;


        public EnemyHealthUIManager(EnemyController enemyController)
        {
            _enemyController = enemyController;



            enemyHealthUI = _enemyController.EnemyHealthUI;

            //enemyHealthUI.text = _enemyController.Health.ToString();

            EventManager.EnemyGetHit += SetEnemyHealthUI;

        }


        private void SetEnemyHealthUI()
        {
            _enemyHealth = _enemyController.Health;

            enemyHealthUI.text = _enemyHealth.ToString();
        }


        private void OnDisable()
        {
            EventManager.EnemyGetHit -= SetEnemyHealthUI;
        }
    }
}

