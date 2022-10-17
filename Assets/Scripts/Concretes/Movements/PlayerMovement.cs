using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WARDY.Controllers;
using WARDY.Inputs;

namespace WARDY.Movements
{
    public class PlayerMovement
    {
        private PlayerController _playerController;
        Rigidbody _rigidbody;


        //PlayerInput _playerInput;



        public PlayerMovement(PlayerController playerController)
        {
            _playerController = playerController;
            _rigidbody = playerController.GetComponent<Rigidbody>();
            //Debug.Log("playermover oluştu");



        }

        public void FixedTick(float inputValue)
        {
            _rigidbody.transform.Translate(new Vector3(_playerController.HorizontalSpeed, inputValue / 10, 0));
            //_rigidbody.transform.Translate(new Vector3(0, inputValue / 10, 0));
        }
    }
}


