using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WARDY.Controllers
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] PlayerController _playerController;



        private void FixedUpdate()
        {
            transform.position = new Vector3(_playerController.transform.position.x + 9, 0, -10);
        }
    }
}


