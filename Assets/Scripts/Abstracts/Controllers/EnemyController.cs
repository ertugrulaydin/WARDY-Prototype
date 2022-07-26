using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using WARDY.Movements;
using WARDY.Controllers;
using WARDY.Managers;


namespace WARDY.Abstracts.Controllers
{
    public class EnemyController : MonoBehaviour, IEnemyDamageable
    {

        public event Action OnEnemyDestroyed;


        EnemyMovement _enemyMovement;
        EnemyFire _enemyFire;

        EnemyHealth _enemyHealth;



        ParticleManager _particleManager;







        protected float horizontalSpeed = 0.025f;



        [SerializeField] Transform bulletTransform;

        protected Rigidbody _rigidbody;

        public ParticleSystem _enemyDestroyParticle;

        [SerializeField] protected float fireRate = 1.24f;
        [SerializeField] protected float _health;






        public Transform BulletTransform => bulletTransform;

        public Rigidbody GetRigidbody => _rigidbody;

        public float FireRate { get => fireRate; protected set => fireRate = value; }
        public float HorizontalSpeed { get => horizontalSpeed; protected set => horizontalSpeed = value; }

        public float Health { get => _health; protected set => _health = value; }




        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();

            _enemyMovement = new EnemyMovement(this);
            _enemyFire = new EnemyFire(this);
            _enemyHealth = new EnemyHealth(this);

            _particleManager = new ParticleManager(this);
        }

        private void FixedUpdate()
        {
            EnemyFire();
            EnemyMove();
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

            Debug.Log("enemy health: " + _health);
            if (_health <= 0)
            {
                //EventManager.Broadcast(OnEnemyDestroyed);
                //EventManager.Broadcast(GameEvent.OnEnemyDestroyed);
                OnEnemyDestroyed?.Invoke();
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
