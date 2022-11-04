using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WARDY.Movements;
using WARDY.Controllers;
using WARDY.Abstracts.Interfaces;
using WARDY.Managers;
using UnityEngine.UI;
using TMPro;

namespace WARDY.Abstracts.Controllers
{
    public abstract class BossController : EnemyController, IBoss, IEnemyDamageable
    {


        #region SerializeField

        [SerializeField] protected GameObject _playerController;

        [SerializeField] private GameObject _secondaryAmmo;

        [SerializeField] private List<GameObject> _secondaryAmmos;

        #endregion


        #region Privates

        BossFirstMovement _bossFirstMovement;

        IPlayerDamageable _playerDamageable;

        EnemyFireSecondary _enemyFireSecondary;




        #endregion


        #region Protected

        protected float _timeCounter = 0;

        protected float _firstMoveSpeed = 0.015f;

        protected bool _firstMoveCompleted = false;

        protected bool _boosCanSecondaryFire = false;


        #endregion


        #region Properties

        public float FirstMoveSpeed => _firstMoveSpeed;

        public bool FirstMoveCompleted { get => _firstMoveCompleted; set => _firstMoveCompleted = value; }


        #endregion


        private void Start()
        {

            _isBoss = true;

            hasSecondaryAmmo = true;


            _bossFirstMovement = new BossFirstMovement(this, _playerController);

            _enemyHealthUIManager = new EnemyHealthUIManager(this);

            _enemyFireSecondary = new EnemyFireSecondary(this, _secondaryAmmo);

        }

        private void Update()
        {

            EnemyFireTimer();

            EnemyFire();

            if (_boosCanSecondaryFire && !StopSecondaryFire)
            {

                EnemySecondaryFireTimer();

                EnemySecondaryFire(_enemyFireSecondary);

            }

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

