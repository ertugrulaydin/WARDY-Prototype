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

        //[SerializeField] protected float fireRate;

        //[SerializeField] Transform bulletTransform;

        //[SerializeField] RawImage _healthBarImage;

        //[SerializeField] GameObject _healthPanel;

        //[SerializeField] private TMP_Text _enemyHealthUI;

        #endregion


        #region Privates

        BossFirstMovement _bossFirstMovement;

        IPlayerDamageable _playerDamageable;

        //EnemyHealth _enemyHealth;

        //EnemyFire _enemyFire;

        #endregion


        #region Protected

        protected float _timeCounter = 0;

        protected float _firstMoveSpeed = 0.015f;

        protected bool _firstMoveCompleted = false;

        //protected float _health;

        //protected EnemyHealthUIManager _enemyHealthUIManager;

        #endregion


        #region Properties

        public float FirstMoveSpeed => _firstMoveSpeed;

        public bool FirstMoveCompleted { get => _firstMoveCompleted; set => _firstMoveCompleted = value; }
        //public float Health { get => _health; set => _health = value; }
        //public float FireRate { get => fireRate; set => fireRate = value; }

        //public Transform BulletTransform => bulletTransform;

        //public RawImage HealthBarImage { get => _healthBarImage; set => _healthBarImage = value; }

        //public GameObject HealthPanel { get => _healthPanel; set => _healthPanel = value; }

        //public TMP_Text EnemyHealthUI { get => _enemyHealthUI; }

        #endregion


        private void Start()
        {

            _isBoss = true;

            _bossFirstMovement = new BossFirstMovement(this, _playerController);

            _enemyHealthUIManager = new EnemyHealthUIManager(this);
            //Debug.Log("isboss: " + _isBoss);
        }

        /*
                protected void SubClassCreated()
                {



                    //_enemyHealth = new EnemyHealth(this.gameObject);

                    //_enemyFire = new EnemyFire(this.gameObject);



                }
                */



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

            EnemyFire();

        }
        /*
        private void OnTriggerEnter(Collider other)
        {
            _playerDamageable = other.gameObject.GetComponent<IPlayerDamageable>();

            if (_playerDamageable != null)
            {

                EventManager.PlayerTouchSomething(this.gameObject);

                this.gameObject.SetActive(false);

            }
        }

        */

        public abstract void UpdatePositionAfterFirstMovement(Vector3 updatedPosition);


        public abstract void BossAction();


        /*
                public void Damage(float damage)
                {
                    _health = _enemyHealth.IncreaseHealth(damage);

                    Debug.Log(_health);

                    EventManager.OnEnemyGetHit(this);

                    if (_health <= 0)
                    {

                        //EventManager.OnEnemyDestroyed(gameObject);

                        this.gameObject.SetActive(false);

                    }
                }

                */
    }
}

