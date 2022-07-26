using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WARDY.Controllers;

public class BasicBullet : MonoBehaviour
{

    [SerializeField] float _damage;
    BulletController _bulletController;



    GameObject _parent;
    IPlayerDamageable playerdamageable;
    IEnemyDamageable enemydamageable;


    private void OnTriggerEnter(Collider other)
    {

        _bulletController = GetComponentInParent<BulletController>();
        _parent = other.gameObject;
        playerdamageable = _parent.GetComponent<IPlayerDamageable>();
        enemydamageable = _parent.GetComponent<IEnemyDamageable>();

        if (playerdamageable != null && _bulletController.Direction == -1)
        {
            playerdamageable.Damage(_damage);
            this.gameObject.SetActive(false);
        }

        if (enemydamageable != null && _bulletController.Direction == 1)
        {
            this.gameObject.SetActive(false);
            enemydamageable.Damage(_damage);

        }
    }

}
