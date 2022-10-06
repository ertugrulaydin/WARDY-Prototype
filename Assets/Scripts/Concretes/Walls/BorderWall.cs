using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WARDY.Managers;


namespace WARDY.Walls
{
    public class BorderWall : MonoBehaviour
    {
        #region Private

        IEnemyDamageable _enemydamageable;

        #endregion

        private void OnTriggerEnter(Collider other)
        {

            _enemydamageable = other.gameObject.GetComponent<IEnemyDamageable>();


            if (_enemydamageable != null)
            {
                other.gameObject.SetActive(false);
                EventManager.OnEnemyDestroyedByBorder();
            }
        }
    }
}

