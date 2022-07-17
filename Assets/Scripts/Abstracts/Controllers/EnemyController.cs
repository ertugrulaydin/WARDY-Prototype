using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using WARDY.Movements;
using WARDY.Controllers;


namespace WARDY.Abstracts.Controllers
{
    public class EnemyController : MonoBehaviour, IEnemyDamageable
    {

        EnemyMovement _enemyMovement;
        EnemyFire _enemyFire;

        EnemyHealth _enemyHealth;





        float horizontalSpeed = 0.01f;



        [SerializeField] Transform bulletTransform;

        protected Rigidbody _rigidbody;

        [SerializeField] protected float fireRate;
        [SerializeField] protected float _health;




        public Transform BulletTransform => bulletTransform;

        public Rigidbody GetRigidbody => _rigidbody;

        public float FireRate => fireRate;
        public float HorizontalSpeed => horizontalSpeed;

        public float Health => _health;







        protected void EnemyControllerFunctions()
        {
            _enemyMovement = new EnemyMovement(this);
            _enemyFire = new EnemyFire(this);
            _enemyHealth = new EnemyHealth(this);

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

        }


        //movement

        //fire

        //health?

        //damage?

    }
}
