using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WARDY.Abstracts.Controllers;

namespace WARDY.Controllers.EnemyControllers.Kevs
{
    public class KevA : EnemyController
    {

        public override void SetDefaultVariables()
        {

            fireRate = 3f;

            _horizontalSpeed = 0.025f;

            _health = 100f;

            SubClassCreated();

        }
    }
}

