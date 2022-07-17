using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WARDY.Controllers
{
    public class BulletController : MonoBehaviour
    {
        [SerializeField] float bulletSpeed = 15f;

        Rigidbody _rigidbody;

        [SerializeField] float bulletLifeTime;
        float tempLifeTime;

        [SerializeField] int direction;

        [SerializeField] float countdown;


        public int Direction => direction;









        private void Awake()
        {

            _rigidbody = GetComponent<Rigidbody>();


        }

        private void Start()
        {
            tempLifeTime = bulletLifeTime;
        }


        private void FixedUpdate()
        {


            bulletLifeTime -= countdown;


            if (direction == 1)
            {
                _rigidbody.velocity = Vector2.right * bulletSpeed;
            }

            else if (direction == -1)
            {
                _rigidbody.velocity = Vector2.left * bulletSpeed;
            }






            if (bulletLifeTime <= 0f)
            {
                gameObject.SetActive(false);
                bulletLifeTime = tempLifeTime;
            }




        }





    }
}
