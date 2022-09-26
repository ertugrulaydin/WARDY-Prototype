using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WARDY.Controllers;

namespace WARDY.Movements
{
    public class WallMovement : MonoBehaviour
    {
        #region SerializeFields
        [SerializeField] PlayerController _playerController = null;
        #endregion

        #region Privates
        private Vector3 _wallPos = new Vector3(0f, 0f, 0f);
        #endregion

        private void Start()
        {
            if (_playerController == null)
            {

                Debug.Log("Add PlayerController Reference to Walls");

            }
        }

        private void FixedUpdate()
        {

            _wallPos.x = _playerController.transform.position.x;
            transform.position = _wallPos;

        }
    }
}


