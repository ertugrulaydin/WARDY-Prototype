using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


using WARDY.Movements;
using WARDY.Controllers;
using WARDY.Managers;
using TMPro;

namespace WARDY.Abstracts.Controllers
{
    public abstract class EnemyController : MonoBehaviour, IEnemyDamageable
    {

        EnemyMovement _enemyMovement;
        EnemyFire _enemyFire;
        EnemyHealth _enemyHealth;
        ParticleManager _particleManager;
        protected EnemyHealthUIManager _enemyHealthUIManager;
        protected EnemyVerticalMovement _enemyVerticalMovement;

        IPlayerDamageable _playerDamageable;

        EnemyController _enemyController;

        protected Animator _enemyAnimator;

        float _basicFireTimer = 0;

        protected bool hasSecondaryAmmo = false;

        float _secondaryAmmoTimer = 0;

        protected float _secondaryAmmoFireRate;

        bool _canFire = false;

        bool _canSecondaryFire = false;

        EnemyFireSecondary _enemyFireSecondary;

        private bool stopSecondaryFire = false;

        //int _countsomething = 0;








        protected float _horizontalSpeed = 0.005f;

        protected float _verticalSpeed;

        protected bool _verticalMovement = false;
        bool _isSubClassCreated = false;






        [SerializeField] Transform bulletTransform;

        protected Rigidbody _rigidbody;

        public ParticleSystem _enemyDestroyParticle;

        [SerializeField] protected float fireRate;
        protected float _health;

        protected bool _isBoss = false;

        [SerializeField] protected float _scoreMultiplier;

        [SerializeField] RawImage _healthBarImage;

        [SerializeField] GameObject _healthPanel;

        [SerializeField] private TMP_Text _enemyHealthUI;






        public Transform BulletTransform => bulletTransform;

        public Rigidbody GetRigidbody => _rigidbody;



        public float FireRate { get => fireRate; protected set => fireRate = value; }
        public float HorizontalSpeed { get => _horizontalSpeed; protected set => _horizontalSpeed = value; }

        public float Health { get => _health; protected set => _health = value; }

        public float ScoreMultiplier { get => _scoreMultiplier; protected set => _scoreMultiplier = value; }

        public TMP_Text EnemyHealthUI { get => _enemyHealthUI; }

        public float VerticalSpeed { get => _verticalSpeed; protected set => _verticalSpeed = value; }

        public RawImage HealthBarImage { get => _healthBarImage; set => _healthBarImage = value; }

        public GameObject HealthPanel { get => _healthPanel; set => _healthPanel = value; }

        public bool IsBoos => _isBoss;

        public Animator EnemyAnimator { get => _enemyAnimator; set => _enemyAnimator = value; }
        public bool StopSecondaryFire { get => stopSecondaryFire; set => stopSecondaryFire = value; }

        protected void SubClassCreated()
        {

            _rigidbody = GetComponent<Rigidbody>();

            EnemyAnimator = GetComponent<Animator>();

            _enemyMovement = new EnemyMovement(this);

            _enemyFire = new EnemyFire(this);

            _enemyHealth = new EnemyHealth(this);

            //_particleManager = new ParticleManager();
            _enemyHealthUIManager = new EnemyHealthUIManager(this);

            if (_verticalMovement)
            {

                _enemyVerticalMovement = new EnemyVerticalMovement(this);
            }

            _isSubClassCreated = true;
        }



        private void FixedUpdate()
        {
            if (_isSubClassCreated)
            {

                EnemyMove();

                if (_verticalMovement)
                {

                    _enemyVerticalMovement.FixedTick(transform.position);

                }

            }

        }


        protected void EnemyMove()
        {

            _enemyMovement.Move();

        }

        protected void EnemyFireTimer()
        {

            _basicFireTimer += Time.deltaTime;

            if (_basicFireTimer >= fireRate)
            {

                _canFire = true;

                _basicFireTimer = 0;

            }

        }



        protected void EnemyFire()

        {

            if (_canFire)
            {

                _enemyFire.FixedTick();

                _enemyAnimator?.Play("Kevs_Fire", 1);

                _canFire = false;

            }

        }

        protected void EnemySecondaryFireTimer()
        {

            _secondaryAmmoTimer += Time.deltaTime;

            if (_secondaryAmmoTimer >= _secondaryAmmoFireRate)
            {
                _canSecondaryFire = true;

                _secondaryAmmoTimer = 0;

            }

        }

        protected void EnemySecondaryFire(EnemyFireSecondary enemyFireSecondary)
        {

            _enemyFireSecondary = enemyFireSecondary;

            if (_canSecondaryFire)
            {

                _enemyFireSecondary.FixedTick();

                _canSecondaryFire = false;

            }

        }

        public void Damage(float damage)
        {
            _health = _enemyHealth.IncreaseHealth(damage);

            EventManager.OnEnemyGetHit(this);

            if (_health <= 0)
            {

                EventManager.OnEnemyDestroyed(gameObject);

                this.gameObject.SetActive(false);

            }

        }

        private void OnTriggerEnter(Collider other)
        {
            _playerDamageable = other.gameObject.GetComponent<IPlayerDamageable>();

            if (_playerDamageable != null)
            {

                EventManager.PlayerTouchSomething(this.gameObject);

                if (!_isBoss)
                {

                    this.gameObject.SetActive(false);

                }


            }
        }

        public abstract void SetDefaultVariables();


    }
}
