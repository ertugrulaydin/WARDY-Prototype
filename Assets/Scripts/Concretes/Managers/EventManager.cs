using System;
using System.Collections.Generic;
using UnityEngine;
using WARDY.Abstracts.Controllers;

namespace WARDY.Managers
{
    public static class EventManager
    {


        public static event Action<GameObject> EnemyDestroyed;
        public static event Action<EnemyController> EnemyGetHit;

        public static event Action EnemyDestroyedByWall;

        public static event Action BossAction;

        public static event Action<GameObject> ReducePlayerChange;

        public static event Action StartGame;

        public static event Action GameOver;

        //public static event Action EnemySpawned;





        public static void OnEnemyDestroyed(GameObject _gameObject) => EnemyDestroyed?.Invoke(_gameObject);

        public static void OnEnemyGetHit(EnemyController enemyController) => EnemyGetHit?.Invoke(enemyController);

        public static void OnEnemyDestroyedByBorder() => EnemyDestroyedByWall?.Invoke();

        public static void OnBossActionStarted() => BossAction?.Invoke();

        public static void PlayerTouchSomething(GameObject obj) => ReducePlayerChange?.Invoke(obj);

        public static void OnStartGame() => StartGame?.Invoke();

        public static void OnGameOver() => GameOver?.Invoke();

        //public static void OnEnemySpawned() => EnemySpawned.Invoke();
    }
}
