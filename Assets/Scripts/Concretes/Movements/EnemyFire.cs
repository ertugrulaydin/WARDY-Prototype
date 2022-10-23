using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WARDY.Abstracts.Controllers;
using WARDY.ObjectPools;


namespace WARDY.Movements
{
    public class EnemyFire
    {
        EnemyController _enemyController;

        BossController _bossController;

        EnemyBasicBulletPool _enemyBasicBulletPool;

        float fireRate;

        GameObject parentObject;

        Transform _bulletTransform;



        //public EnemyFire(GameObject enemy)
        public EnemyFire(EnemyController enemyController)
        {

            //if (enemy.GetComponent<EnemyController>() != null)
            //{

            _enemyController = enemyController.GetComponent<EnemyController>();

            fireRate = _enemyController.FireRate;

            _bulletTransform = _enemyController.BulletTransform;

            //}
            /*
            else if (enemy.GetComponent<BossController>() != null)
            {

                _bossController = enemy.GetComponent<BossController>();

                fireRate = _bossController.FireRate;

                _bulletTransform = _bossController.BulletTransform;

            }

            */





            parentObject = enemyController.transform.gameObject;

            _enemyBasicBulletPool = parentObject.GetComponentInChildren<EnemyBasicBulletPool>();



        }




        public void FixedTick()
        {

            GameObject bullet = _enemyBasicBulletPool.GetPooledObject(fireRate);

            if (bullet != null)
            {

                bullet.transform.position = _bulletTransform.position;

                bullet.SetActive(true);

            }




        }
    }


}
