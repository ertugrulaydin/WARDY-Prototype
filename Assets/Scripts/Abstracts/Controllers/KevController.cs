using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WARDY.Abstracts.Controllers
{
    public class KevController : EnemyController
    {

        private float _kevsHealth = 50f;


        protected void KevsValues()
        {

            FireRate = 0.9f;

            _health = _kevsHealth;

            ScoreMultiplier = 1.25f;

        }

        public void DefaultHealth() => _health = _kevsHealth;

    }
}