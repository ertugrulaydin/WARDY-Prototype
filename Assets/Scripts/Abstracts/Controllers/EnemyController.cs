using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using WARDY.Movements;
using WARDY.Controllers;
using WARDY.Managers;
using TMPro;

namespace WARDY.Abstracts.Controllers
{
    public class EnemyController : MonoBehaviour, IEnemyDamageable
    {

        //public event Action OnEnemyDestroyed;


        EnemyMovement _enemyMovement;
        EnemyFire _enemyFire;
        EnemyHealth _enemyHealth;
        ParticleManager _particleManager;
        protected EnemyHealthUIManager _enemyHealthUIManager;

        EnemyVerticalMovement _enemyVerticalMovement;







        protected float _horizontalSpeed = 0.025f;

        protected bool _verticalMovement;



        [SerializeField] Transform bulletTransform;

        protected Rigidbody _rigidbody;

        public ParticleSystem _enemyDestroyParticle;

        [SerializeField] protected float fireRate = 1.24f;
        protected float _health;

        [SerializeField] protected float _scoreMultiplier;






        public Transform BulletTransform => bulletTransform;

        public Rigidbody GetRigidbody => _rigidbody;

        [SerializeField] private TMP_Text _enemyHealthUI;

        public float FireRate { get => fireRate; protected set => fireRate = value; }
        public float HorizontalSpeed { get => _horizontalSpeed; protected set => _horizontalSpeed = value; }

        public float Health { get => _health; protected set => _health = value; }

        public float ScoreMultiplier { get => _scoreMultiplier; protected set => _scoreMultiplier = value; }

        public TMP_Text EnemyHealthUI { get => _enemyHealthUI; }






        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();

            _enemyMovement = new EnemyMovement(this);
            _enemyFire = new EnemyFire(this);
            _enemyHealth = new EnemyHealth(this);
            _particleManager = new ParticleManager();
            _enemyHealthUIManager = new EnemyHealthUIManager(this);
            _enemyVerticalMovement = new EnemyVerticalMovement(this);



        }


        private void FixedUpdate()
        {
            EnemyFire();
            EnemyMove();
            if (_verticalMovement)
            {
                _enemyVerticalMovement.VerticalMove(this.transform);
            }
        }




        protected void EnemyMove()
        {

            _enemyMovement.Move();

        }



        protected void EnemyFire()
        {

            _enemyFire.FixedTick();

        }

        public void Damage(float damage)
        {
            _health = _enemyHealth.IncreaseHealth(damage);

            EventManager.OnEnemyGetHit();
            //Debug.Log("enemy health: " + _health);
            if (_health <= 0)
            {
                //EventManager.Broadcast(OnEnemyDestroyed);
                //EventManager.Broadcast(GameEvent.OnEnemyDestroyed);



                //OnEnemyDestroyed?.Invoke();



                //Messenger.Broadcast<Transform>("transform", gameObject.transform);

                EventManager.OnEnemyDestroyed(gameObject);

                //EventManager.Broadcast(EventManager.EnemyDestroyed);


                this.gameObject.SetActive(false);


            }

        }

        protected void InstantiateParticle()
        {
            //_enemyDeathParticlesController.InstantiateEnemyDeathParticles(_deathParticles, this.transform);
        }



        //movement

        //fire

        //health?

        //damage?

    }
}
