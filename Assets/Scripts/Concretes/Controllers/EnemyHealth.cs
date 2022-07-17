using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using WARDY.Abstracts.Controllers;

namespace WARDY.Controllers
{
    public class EnemyHealth
    {
        EnemyController _enemyController;
        float _playerHealt;

        public EnemyHealth(EnemyController enemyController)
        {
            _enemyController = enemyController;
        }

        public float IncreaseHealth(float damage)
        {
            _playerHealt = _enemyController.Health;
            _playerHealt -= damage;
            return _playerHealt;
        }

    }
}
