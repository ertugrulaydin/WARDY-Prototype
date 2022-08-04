using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WARDY.Inputs;
using WARDY.ObjectPools;
using WARDY.Movements;


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



        float _inputValue;

        float _horizontalSpeed = 0.01f;

        float _health = 100;

        bool _isFire;

        Vector3 _playerPosition;



        [SerializeField] Transform bulletTransform;


        public float HorizontalSpeed => _horizontalSpeed;

        public Transform BulletTransform => bulletTransform;

        public bool IsFire => _isFire;

        public float Health => _health;

        public Vector3 PlayerPosition => _playerPosition;

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

        }


        private void Update()
        {

            _isFire = _input.isFire;

            _inputValue = _input.isUpDown;

        }



        private void FixedUpdate()
        {
            _playerPosition = this.transform.position;
            _playerMovement.FixedTick(_inputValue);
            _playerFire.Tick();

        }

        public void Damage(float damage)
        {
            _health = _playerHealth.IncreaseHealth(damage);


            if (_health <= 0)
            {
                Time.timeScale = 0;
            }
        }



        /*

        IEnumerator PlayerFire()
        {

            yield return new WaitForSeconds(.1f);
        }
        
        private void FireListener()
        {

        }
        
        void PlayerMovement(float inputValue)
        {

        _rigidbody.transform.Translate(new Vector3(0, inputValue / 10, 0));

        }


        public void Fire()
        {
        GameObject bullet = BasicBulletPool._instance.GetPooledObject();

        if (bullet != null)
        {
            bullet.transform.position = bulletTransform.position;
            bullet.SetActive(true);
        }

        }


        private void InputListener()
        {


        _input.PlayerMove.UpDown.performed += context => PlayerMovement(context.ReadValue<float>());

        _input.PlayerMove.Fire.performed += context => Fire();


        }
        */


    }
}


