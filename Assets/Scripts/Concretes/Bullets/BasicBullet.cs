using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WARDY.Controllers;

public class BasicBullet : MonoBehaviour
{

    [SerializeField] float _damage;
    BulletController _bulletController;
    private void OnTriggerEnter(Collider other)
    {

        _bulletController = GetComponentInParent<BulletController>();
        GameObject _parent = other.gameObject;
        IPlayerDamageable playerdamageable = _parent.GetComponent<IPlayerDamageable>();
        IEnemyDamageable enemydamageable = _parent.GetComponent<IEnemyDamageable>();



        //if (playerdamageable != null && other.gameObject != _parent)
        //if (other.gameObject.GetComponent<IPlayerDamageable>() != null && _bulletController.Direction == -1)
        if (playerdamageable != null && _bulletController.Direction == -1)
        {


            //IPlayerDamageable playerdamageable = other.gameObject.GetComponent<IPlayerDamageable>();
            playerdamageable.Damage(_damage);
            this.gameObject.SetActive(false);

        }

        //if (other.gameObject.GetComponent<IEnemyDamageable>() != null && _bulletController.Direction == 1)
        if (enemydamageable != null && _bulletController.Direction == 1)
        {

            //IEnemyDamageable enemydamageable = other.gameObject.GetComponent<IEnemyDamageable>();
            enemydamageable.Damage(_damage);
            this.gameObject.SetActive(false);
        }
    }

}
