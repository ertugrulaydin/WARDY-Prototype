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
            _verticalMovement = false;
            KevsValues();
            Debug.Log(Health);
            _enemyHealthUIManager.InitializeEnemyHealthUI(Health);

        }
    }
}

