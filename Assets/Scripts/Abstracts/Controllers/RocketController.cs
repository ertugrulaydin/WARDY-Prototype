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

        #endregion

        #region Private

        Vector3 _destinationPoint;

        Vector3 _startPoint;

        float _moveAngle;


        #endregion

        #region Protected

        protected Rigidbody _rigidbody;
        protected bool canFire = false;

        #endregion

        #region Property

        public int Direction => direction;

        #endregion

        private void Awake()
        {

            _rigidbody = GetComponent<Rigidbody>();


        }


        protected void RocketMove()
        {

            if (canFire)
            {

                _rigidbody.AddRelativeForce(Vector3.back * bulletSpeed);

            }

        }

        public void PrepareToFire()
        {

            SetStartPoint();

            SetDestination();

            transform.parent = null;

            canFire = true;

            Quaternion rotation = Quaternion.Euler(_moveAngle, -90, 0);

            transform.rotation = rotation;

        }

        private void SetStartPoint()
        {

            transform.position = new Vector3(transform.position.x, transform.parent.transform.position.y, 0);

        }

        private void SetDestination()
        {

            _startPoint = transform.position;

            _destinationPoint = _player.transform.position;

            _moveAngle = Mathf.Atan2(_player.transform.position.y - transform.parent.transform.position.y, _player.transform.position.x - transform.parent.transform.position.x) * Mathf.Rad2Deg;

        }

    }
}

