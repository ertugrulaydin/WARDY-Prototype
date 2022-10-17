using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WARDY.Movements;
using WARDY.Controllers;
using WARDY.Abstracts.Interfaces;
using WARDY.Managers;


namespace WARDY.Abstracts.Controllers
{
    public abstract class BossController : MonoBehaviour, IBoss, IEnemyDamageable
    {


        #region SerializeField

        [SerializeField] protected GameObject _playerController;

        #endregion


        #region Privates

        BossFirstMovement _bossFirstMovement;

        IPlayerDamageable _playerDamageable;

        EnemyHealth _enemyHealth;

        #endregion


        #region Protected

        protected float _timeCounter = 0;

        protected float _firstMoveSpeed = 0.015f;

        protected bool _firstMoveCompleted = false;

        protected float _health;

        #endregion


        #region Properties

        public float FirstMoveSpeed => _firstMoveSpeed;

        public bool FirstMoveCompleted { get => _firstMoveCompleted; set => _firstMoveCompleted = value; }
        public float Health { get => _health; set => _health = value; }

        #endregion


        protected void SubClassCreated()
        {

            _bossFirstMovement = new BossFirstMovement(this, _playerController);

            _enemyHealth = new EnemyHealth(this.gameObject);

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

        private void OnTriggerEnter(Collider other)
        {
            _playerDamageable = other.gameObject.GetComponent<IPlayerDamageable>();

            if (_playerDamageable != null)
            {

                EventManager.PlayerTouchSomething(this.gameObject);

                this.gameObject.SetActive(false);

            }
        }

        public abstract void UpdatePositionAfterFirstMovement(Vector3 updatedPosition);


        public abstract void BossAction();

        public void Damage(float damage)
        {
            _health = _enemyHealth.IncreaseHealth(damage);

            Debug.Log(_health);

            //EventManager.OnEnemyGetHit(this);

            if (_health <= 0)
            {

                //EventManager.OnEnemyDestroyed(gameObject);

                this.gameObject.SetActive(false);

            }
        }
    }
}

