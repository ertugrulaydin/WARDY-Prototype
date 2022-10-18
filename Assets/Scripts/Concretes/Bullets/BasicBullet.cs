using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WARDY.Managers;
using WARDY.Abstracts.Controllers;


public class BasicBullet : BulletController
{

    [SerializeField] float _damage;
    BulletController _bulletController;
    GameObject _parent;
    IPlayerDamageable playerdamageable;
    IEnemyDamageable enemydamageable;

    public float Damage => _damage;


    private void OnTriggerEnter(Collider other)
    {
        GiveDamage(other);
    }

    public override void GiveDamage(Collider other)
    {

        _bulletController = GetComponentInParent<BulletController>();
        _parent = other.gameObject;
        playerdamageable = _parent.GetComponent<IPlayerDamageable>();
        enemydamageable = _parent.GetComponent<IEnemyDamageable>();

        if (playerdamageable != null && _bulletController.Direction == -1)
        {
            //playerdamageable.Damage(_damage);
            EventManager.PlayerTouchSomething(this.gameObject);
            this.gameObject.SetActive(false);
        }

        if (enemydamageable != null && _bulletController.Direction == 1)
        {
            this.gameObject.SetActive(false);
            enemydamageable.Damage(_damage);

        }

        if (other.tag == "BorderWall")
        {

            this.gameObject.SetActive(false);

        }
    }

}
