using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WARDY.Abstracts.Controllers;

namespace WARDY.Movements
{
    public class EnemyVerticalMovement
    {

        EnemyController _enemyController;

        Rigidbody _rigidbody;

        Vector3 _destination;



        public EnemyVerticalMovement(EnemyController enemyController)
        {

            _enemyController = enemyController;
            _rigidbody = _enemyController.GetComponent<Rigidbody>();
            _destination = new Vector3(0, 1, 0);

        }

        public void VerticalMove(Transform enemyPosition)
        {
            //_rigidbody.transform.Translate(Vector3.Lerp(enemyPosition.position, (enemyPosition.position - _destination), 0.001f));
        }
    }
}

