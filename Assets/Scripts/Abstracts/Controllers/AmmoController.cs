using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WARDY.Managers;
using WARDY.Abstracts.Interfaces;


namespace WARDY.Abstracts.Controllers
{
    public class AmmoController : MonoBehaviour, IBullet
    {

        [SerializeField] protected float _damage;

        public float Damage => _damage;

        [SerializeField] protected int direction;

        GameObject _parent;
        IPlayerDamageable playerdamageable;
        IEnemyDamageable enemydamageable;

        private void OnTriggerEnter(Collider other)
        {
            GiveDamage(other);
        }

        public void GiveDamage(Collider other)
        {

            _parent = other.gameObject;

            playerdamageable = _parent.GetComponent<IPlayerDamageable>();

            enemydamageable = _parent.GetComponent<IEnemyDamageable>();



            if (playerdamageable != null && direction == -1)
            {
                EventManager.PlayerTouchSomething(this.gameObject);
                this.gameObject.SetActive(false);
            }

            if (enemydamageable != null && direction == 1)
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
}

