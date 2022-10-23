using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using WARDY.Abstracts.Controllers;

namespace WARDY.Controllers
{
    public class EnemyHealth
    {
        EnemyController _enemyController;

        BossController _bossController;
        float _enemyHealth;
        /* 
                public EnemyHealth(EnemyController enemyController)
                {
                    _enemyController = enemyController;
                }
         */

        public EnemyHealth(EnemyController enemyController)
        {
            _enemyController = enemyController.GetComponent<EnemyController>();

            if (_enemyController == null)
            {
                _bossController = enemyController.GetComponent<BossController>();
            }
        }

        public float IncreaseHealth(float damage)
        {

            if (_enemyController != null)
            {

                _enemyHealth = _enemyController.Health;

            }
            else
            {

                _enemyHealth = _bossController.Health;

            }
            _enemyHealth -= damage;

            return _enemyHealth;
        }

    }
}
