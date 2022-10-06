using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WARDY.Controllers;


namespace WARDY.Movements
{
    public class BorderWallMovement : MonoBehaviour
    {
        #region SerializeField

        [SerializeField] PlayerController _playerController;

        #endregion




        private void FixedUpdate()
        {

            transform.position = transform.position + new Vector3(_playerController.HorizontalSpeed, 0, 0);

        }
    }
}

