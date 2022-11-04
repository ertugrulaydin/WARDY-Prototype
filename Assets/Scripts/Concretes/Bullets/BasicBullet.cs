using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WARDY.Managers;
using WARDY.Abstracts.Controllers;



namespace WARDY.Bullets
{
    public class BasicBullet : BulletController
    {

        private void Start()
        {
            _damage = 25f;
        }

    }

}

