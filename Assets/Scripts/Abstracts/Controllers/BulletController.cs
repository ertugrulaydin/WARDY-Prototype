using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WARDY.Abstracts.Interfaces;
using WARDY.Managers;

namespace WARDY.Abstracts.Controllers
{
    public abstract class BulletController : AmmoController
    {
        [SerializeField] float bulletSpeed = 15.5f;

        Rigidbody _rigidbody;



        private void Awake()
        {

            _rigidbody = GetComponent<Rigidbody>();


        }


        private void FixedUpdate()
        {

            if (direction == 1)
            {
                _rigidbody.velocity = Vector2.right * bulletSpeed;
            }

            else if (direction == -1)
            {
                _rigidbody.velocity = Vector2.left * bulletSpeed;
            }

        }


    }
}


