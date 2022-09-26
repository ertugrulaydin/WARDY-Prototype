using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WARDY.Abstracts.Controllers;

namespace WARDY.Controllers.EnemyControllers.Kevs
{
    public class KevA : KevController
    {
        private void Start()
        {
            fireRate = 3f;

            _horizontalSpeed = 0.015f;

            SubClassCreated();

            KevsValues();

            _enemyHealthUIManager.InitializeEnemyHealthUI(Health);

        }
    }
}

