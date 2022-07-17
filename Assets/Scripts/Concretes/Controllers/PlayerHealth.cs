using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using WARDY.Controllers;


namespace WARDY.Controllers
{
    public class PlayerHealth
    {
        PlayerController _playerController;
        float _playerHealt;

        public PlayerHealth(PlayerController playerController)
        {
            _playerController = playerController;
        }

        public float IncreaseHealth(float damage)
        {
            _playerHealt = _playerController.Health;
            _playerHealt -= damage;
            return _playerHealt;
        }

    }
}

