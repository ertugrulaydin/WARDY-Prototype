using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WARDY.Controllers;


namespace WARDY.Abstracts.Controllers
{
    public class RocketController : AmmoController
    {

        #region SerializeField

        [SerializeField] PlayerController _player;

        [SerializeField] float bulletSpeed = 15f;

        //[SerializeField] int direction;

        #endregion

        #region Private

        Rigidbody _rigidbody;

        Vector3 _destinationPoint;

        Vector3 _startPoint;

        float _lerpValue = 0;


        #endregion

        #region Public

        public bool canFire = false;

        #endregion

        #region Property

        public int Direction => direction;

        #endregion

        private void Awake()
        {

            _rigidbody = GetComponent<Rigidbody>();


        }


        private void FixedUpdate()
        {

            //only enemy can use rocket, for now.(direction == -1)
            if (canFire)
            {

                transform.position = Vector3.Lerp(_startPoint, _destinationPoint, _lerpValue);

                _lerpValue += 0.02f;

                if (_lerpValue >= 1)
                {

                    transform.position = Vector2.left * bulletSpeed;

                }

            }


        }

        public void SetDestination()
        {

            _startPoint = transform.position;

            _destinationPoint = _player.transform.position;

        }

    }
}

