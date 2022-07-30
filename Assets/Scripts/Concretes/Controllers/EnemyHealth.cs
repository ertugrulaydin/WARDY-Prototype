using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using WARDY.Abstracts.Controllers;

namespace WARDY.Controllers
{
    public class EnemyHealth
    {
        EnemyController _enemyController;
        float _enemyHealt;

        public EnemyHealth(EnemyController enemyController)
        {
            _enemyController = enemyController;
        }

        public float IncreaseHealth(float damage)
        {
            _enemyHealt = _enemyController.Health;
            _enemyHealt -= damage;
            return _enemyHealt;
        }

    }
}
