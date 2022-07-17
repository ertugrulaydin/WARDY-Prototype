using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace WARDY.Inputs
{
    public class PlayerInput
    {
        DefaultAction _input;

        public float isUpDown { get; private set; }
        public bool isFire { get; private set; }

        public PlayerInput()
        {

            _input = new DefaultAction();

            _input.PlayerMove.UpDown.performed += context => isUpDown = context.ReadValue<float>();
            _input.PlayerMove.Fire.performed += context => isFire = context.ReadValueAsButton();


            _input.Enable();
        }


    }
}

