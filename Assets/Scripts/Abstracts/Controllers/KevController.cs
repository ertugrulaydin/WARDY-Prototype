using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WARDY.Abstracts.Controllers
{
    public class KevController : EnemyController
    {


        protected void KevsValues()
        {
            _horizontalSpeed = 0.025f;
            //HorizontalSpeed = 0.025f;
            FireRate = 0.9f;
            _health = 75f;
            ScoreMultiplier = 1.25f;

        }
    }
}