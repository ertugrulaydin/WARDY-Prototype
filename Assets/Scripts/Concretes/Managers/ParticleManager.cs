using UnityEngine;
using WARDY.Abstracts.Controllers;



namespace WARDY.Managers
{
    public class ParticleManager
    {
        //EnemyController _enemyController;
        //Transform particleTransform;
        //public ParticleManager(EnemyController enemyController)
        public ParticleManager()
        {
            //_enemyController = enemyController;
            //_enemyController.OnEnemyDestroyed += InstantiateEnemyDeathParticle;

            //EventManager.EnemyDestroyed += InstantiateEnemyDeathParticle;




        }
        private void OnDisable()
        {
            //EventManager.EnemyDestroyed -= InstantiateEnemyDeathParticle;
        }


        public void InstantiateEnemyDeathParticle(GameObject _gameObjet)
        {
            GameObject.Instantiate(_gameObjet.GetComponent<EnemyController>()._enemyDestroyParticle, _gameObjet.transform.position, _gameObjet.transform.rotation);
        }
    }
}

