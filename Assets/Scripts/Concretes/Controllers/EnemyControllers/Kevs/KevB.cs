using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WARDY.Abstracts.Controllers;

namespace WARDY.Controllers.EnemyControllers.Kevs
{
    public class KevB : KevController

    {

        private void Awake()
        {
            KevsValues();
        }
        private void Start()
        {
            fireRate = 2.5f;
            _horizontalSpeed = 0.015f;
            _verticalMovement = true;
            _verticalSpeed = 0.05f;

            SubClassCreated();

            _enemyHealthUIManager.InitializeEnemyHealthUI(Health);



        }
    }
}