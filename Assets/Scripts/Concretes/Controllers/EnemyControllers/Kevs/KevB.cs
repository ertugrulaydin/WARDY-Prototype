using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WARDY.Abstracts.Controllers;

namespace WARDY.Controllers.EnemyControllers.Kevs
{
    public class KevB : KevController
    {
        private void Start()
        {
            _verticalMovement = true;
            KevsValues();
            Debug.Log(Health);
            _enemyHealthUIManager.InitializeEnemyHealthUI(Health);

        }
    }
}