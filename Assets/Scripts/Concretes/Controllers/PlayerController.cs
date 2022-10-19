using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WARDY.Inputs;
using WARDY.ObjectPools;
using WARDY.Movements;
using WARDY.Managers;
using WARDY.Abstracts.Interfaces;


namespace WARDY.Controllers
{
    public class PlayerController : MonoBehaviour, IPlayerDamageable
    {
        PlayerInput _input;
        PlayerMovement _playerMovement;
        PlayerFire _playerFire;

        PlayerHealth _playerHealth;

        [SerializeField] GameObject _basicBulletPool;

        BasicBulletPool basicBulletPool;

        IEnemyDamageable _enemydamageable;

        IBoss _boss;



        float _inputValue;

        float _horizontalSpeed = 0.01f;

        float _totalHealth = 100;

        float _health;

        bool _isFire;

        bool _canMoveForward = true;

        bool _isImmune = false;

        Vector3 _playerPosition;

        float _immuneTimeCounter = 0f;

        //int debugCounter = 1;



        [SerializeField] Transform bulletTransform;


        public float HorizontalSpeed => _horizontalSpeed;

        public Transform BulletTransform => bulletTransform;

        public bool IsFire => _isFire;

        public float Health { get => _health; set => _health = value; }

        public float TotalHealth => _totalHealth;

        public bool IsImmune { get => _isImmune; set => _isImmune = value; }



        private void Awake()
        {

            GameObject obj = Instantiate(_basicBulletPool);

            _input = new PlayerInput();

            _playerMovement = new PlayerMovement(this);

            _playerFire = new PlayerFire(this);

            _playerHealth = new PlayerHealth(this);




        }

        private void Start()
        {
            EventManager.BossAction += PlayerCanMoveForward;

            _health = _totalHealth;
        }


        private void Update()
        {

            _isFire = _input.isFire;

            _inputValue = _input.isUpDown;

            if (!_canMoveForward)
            {

                _horizontalSpeed = 0;

            }

            if (_isImmune)
            {
                _immuneTimeCounter += Time.time * Time.deltaTime;

                if (_immuneTimeCounter >= 2.5f)
                {
                    _isImmune = false;
                }
            }



        }



        private void FixedUpdate()
        {
            //_playerPosition = this.transform.position;

            _playerMovement.FixedTick(_inputValue);

            _playerFire.Tick();

        }

        public void Damage(float damage)
        {
            _health = _playerHealth.IncreaseHealth(damage);

            //Debug.Log("health: " + _health);
            //debugCounter += 1;

        }

        private void PlayerCanMoveForward()
        {

            _canMoveForward = false;

        }

        private void OnDisable()
        {

            EventManager.BossAction -= PlayerCanMoveForward;

        }

        public void SetPlayerPositionAfterReduceChange()
        {

            transform.position = new Vector3(transform.position.x, 0, 0);

        }

    }
}


