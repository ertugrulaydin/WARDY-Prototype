using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WARDY.Abstracts.Controllers;


namespace WARDY.Movements
{
    public class EnemyMovement
    {
        EnemyController _enemyController;

        Rigidbody _rigidbody;


        public EnemyMovement(EnemyController enemyController)
        {

            _enemyController = enemyController;
            _rigidbody = _enemyController.GetRigidbody;

        }

        public void Move()
        {

            _rigidbody.transform.Translate(new Vector3(-(_enemyController.HorizontalSpeed), 0, 0));

        }

    }
}

