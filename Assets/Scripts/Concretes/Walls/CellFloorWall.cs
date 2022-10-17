using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WARDY.Managers;


namespace WARDY.Walls
{
    public class CellFloorWall : MonoBehaviour
    {
        #region Private

        IPlayerDamageable _playerDamageable;

        #endregion


        private void OnTriggerEnter(Collider other)
        {

            _playerDamageable = other.gameObject.GetComponent<IPlayerDamageable>();

            if (_playerDamageable != null)
            {

                EventManager.PlayerTouchSomething(this.gameObject);

            }
        }
    }
}

