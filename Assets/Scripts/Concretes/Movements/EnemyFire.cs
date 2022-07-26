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

        EnemyBasicBulletPool _enemyBasicBulletPool;

        float fireRate;

        GameObject parentObject;



        public EnemyFire(EnemyController enemyController)
        {

            _enemyController = enemyController;
            //_enemyBasicBulletPool = _enemyController.GetComponent<EnemyBasicBulletPool>();
            fireRate = _enemyController.FireRate;




            //_enemyBasicBulletPool = GameObject.Find("EnemyBasicBulletPool").GetComponent<EnemyBasicBulletPool>();

            parentObject = _enemyController.transform.gameObject;

            _enemyBasicBulletPool = parentObject.GetComponentInChildren<EnemyBasicBulletPool>();



        }


        public void FixedTick()
        {

            //GameObject bullet = _enemyBasicBulletPool.GetPooledObject();
            GameObject bullet = _enemyBasicBulletPool.GetPooledObject(fireRate);
            if (bullet != null)
            {
                bullet.transform.position = _enemyController.BulletTransform.position;

                bullet.SetActive(true);
            }




        }
    }


}
