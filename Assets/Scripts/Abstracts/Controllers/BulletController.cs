using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WARDY.Abstracts.Interfaces;

namespace WARDY.Abstracts.Controllers
{
    public abstract class BulletController : MonoBehaviour, IBullet
    {
        [SerializeField] float bulletSpeed = 15.5f;

        Rigidbody _rigidbody;

        [SerializeField] int direction;

        public int Direction => direction;

        [SerializeField] protected float _damage;

        public float Damage => _damage;




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

        public abstract void GiveDamage(Collider other);
    }
}


