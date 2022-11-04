using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WARDY.Abstracts.Controllers;
using WARDY.Movements;

namespace WARDY.Controllers.EnemyControllers.Kevs
{
    public class KevB : EnemyController
    {

        public override void SetDefaultVariables()
        {
            _health = 100f;

            fireRate = 2.5f;

            _horizontalSpeed = 0.015f;

            _verticalMovement = true;

            _verticalSpeed = 0.05f;

            SubClassCreated();

            _enemyAnimator.speed = 10;

        }

        private void Update()
        {

            EnemyFireTimer();

            EnemyFire();

        }

    }
}