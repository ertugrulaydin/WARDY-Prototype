using System;
using System.Collections.Generic;
using UnityEngine;


namespace WARDY.Managers
{
    public static class EventManager
    {


        public static event Action<GameObject> EnemyDestroyed;
        public static event Action EnemyGetHit;

        public static event Action EnemyDestroyedByWall;

        public static event Action BossAction;

        //public static event Action EnemySpawned;





        public static void OnEnemyDestroyed(GameObject _gameObject) => EnemyDestroyed?.Invoke(_gameObject);

        public static void OnEnemyGetHit() => EnemyGetHit?.Invoke();

        public static void OnEnemyDestroyedByBorder() => EnemyDestroyedByWall?.Invoke();

        public static void OnBossActionStarted() => BossAction?.Invoke();



        //public static void OnEnemySpawned() => EnemySpawned.Invoke();
    }
}
