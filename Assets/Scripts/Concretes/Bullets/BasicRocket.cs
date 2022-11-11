using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WARDY.Abstracts.Controllers;
using WARDY.Movements;


namespace WARDY.Bullets
{
    public class BasicRocket : RocketController
    {
        BasicRocketRotation _basicRocketRotation;

        private void Start()
        {

            _damage = 100f;

            canFire = false;

            _basicRocketRotation = new BasicRocketRotation(this, _rigidbody);

        }

        private void Update()
        {
            if (canFire)
            {

                BasicRocketRotation();

            }


        }


        private void FixedUpdate()
        {
            if (canFire)
            {

                BasiRocketMovement();

            }


        }

        private void BasiRocketMovement()
        {

            RocketMove();

        }

        private void BasicRocketRotation()
        {

            _basicRocketRotation.FixedTick();

        }
    }
}

