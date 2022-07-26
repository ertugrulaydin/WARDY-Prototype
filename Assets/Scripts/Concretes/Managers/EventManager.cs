using System;
using System.Collections.Generic;
using UnityEngine;


namespace WARDY.Managers
{
    public static class EventManager
    {


        public static event Action<GameObject> EnemyDestroyed;
        public static event Action<float> EnemyGetHit;





        public static void OnEnemyDestroyed(GameObject _gameObject) => EnemyDestroyed?.Invoke(_gameObject);

        public static void OnEnemyGetHit(float _scoreMultiplier) => EnemyGetHit?.Invoke(_scoreMultiplier);
    }
}
