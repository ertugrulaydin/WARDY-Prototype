using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WARDY.Movements;
using WARDY.Controllers;
using WARDY.Abstracts.Interfaces;


namespace WARDY.Abstracts.Controllers
{
    public abstract class BossController : MonoBehaviour, IBoss
    {


        #region SerializeField

        [SerializeField] protected GameObject _playerController;

        #endregion


        #region Privates

        BossFirstMovement _bossFirstMovement;

        #endregion


        #region Protected

        protected float _timeCounter = 0;

        protected float _firstMoveSpeed = 0.015f;

        protected bool _firstMoveCompleted = false;

        #endregion


        #region Properties

        public float FirstMoveSpeed() => _firstMoveSpeed;

        public bool FirstMoveCompleted { get => _firstMoveCompleted; set => _firstMoveCompleted = value; }

        #endregion


        protected void SubClassCreated()
        {

            _bossFirstMovement = new BossFirstMovement(this, _playerController);

        }




        private void FixedUpdate()
        {

            if (!_firstMoveCompleted)
            {

                _bossFirstMovement.FixedTick();

            }

            else
            {
                _timeCounter += Time.deltaTime;

                BossAction();

            }

        }

        public abstract void UpdatePositionAfterFirstMovement(Vector3 updatedPosition);


        public abstract void BossAction();





    }
}

