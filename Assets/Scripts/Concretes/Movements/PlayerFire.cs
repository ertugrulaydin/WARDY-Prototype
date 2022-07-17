using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WARDY.Controllers;
using WARDY.ObjectPools;
using WARDY.Abstracts.Controllers;

namespace WARDY.Movements
{
    public class PlayerFire
    {

        PlayerController _playerController;

        BasicBulletPool _basicBulletPool;



        public PlayerFire(PlayerController playerController)
        {

            _playerController = playerController;
            //_basicBulletPool = _playerController.GetComponent<BasicBulletPool>();


        }


        public void Tick()
        {


            //GameObject bullet = _basicBulletPool.GetPooledObject();
            GameObject bullet = BasicBulletPool._instance.GetPooledObject();

            //Debug.Log(bullet);
            if (bullet != null && _playerController.IsFire)
            {
                bullet.transform.position = _playerController.BulletTransform.position;

                bullet.SetActive(true);

            }



        }

        /* IEnumerator BulletSetActive(GameObject bullet)
        {
            Debug.Log("geldi");
            

            yield return new WaitForSeconds(0.5f);
        } */
    }
}


