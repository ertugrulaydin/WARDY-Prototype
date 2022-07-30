using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WARDY.Abstracts.Controllers;

namespace WARDY.Controllers
{
    public class BasicEnemyController : EnemyController
    {

        private void Start()
        {
            HorizontalSpeed = 0.025f;
            FireRate = 0.9f;
            Health = 75f;
            ScoreMultiplier = 1.25f;

            _enemyHealthUIManager.InitializeEnemyHealthUI(Health);
        }



    }
}
