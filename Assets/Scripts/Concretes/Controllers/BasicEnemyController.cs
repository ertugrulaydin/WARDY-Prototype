using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WARDY.Abstracts.Controllers;

namespace WARDY.Controllers
{
    public class BasicEnemyController : EnemyController
    {

        private void Awake()
        {


            _rigidbody = GetComponent<Rigidbody>();

            EnemyControllerFunctions();



        }

        private void Update()
        {

        }

        private void FixedUpdate()
        {

            EnemyFire();
            if (_health <= 0)
            {
                gameObject.SetActive(false);
            }
        }


    }
}
