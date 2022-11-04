using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WARDY.Abstracts.Controllers;


namespace WARDY.Bullets
{
    public class BasicRocket : RocketController
    {

        private void Start()
        {
            _damage = 100f;

            canFire = false;
        }

    }
}

