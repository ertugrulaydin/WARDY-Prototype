using UnityEngine;
using WARDY.Abstracts.Controllers;


namespace WARDY.Managers
{
    public class ParticleManager
    {
        EnemyController _enemyController;
        public ParticleManager(EnemyController enemyController)
        {
            _enemyController = enemyController;
            _enemyController.OnEnemyDestroyed += InstantiateEnemyDeathParticle;



        }



        public void InstantiateEnemyDeathParticle()
        {
            Debug.Log("instantiate");
            GameObject.Instantiate(_enemyController._enemyDestroyParticle, _enemyController.transform.position, _enemyController.transform.rotation);
        }
    }
}

