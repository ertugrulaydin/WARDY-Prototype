using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WARDY.Controllers
{
    public class BulletController : MonoBehaviour
    {
        [SerializeField] float bulletSpeed = 15.5f;

        Rigidbody _rigidbody;

        [SerializeField] int direction;

        public int Direction => direction;




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
