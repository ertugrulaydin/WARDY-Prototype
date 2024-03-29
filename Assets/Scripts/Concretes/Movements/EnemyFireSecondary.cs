using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WARDY.Abstracts.Controllers;
using WARDY.ObjectPools;


namespace WARDY.Movements
{
    public class EnemyFireSecondary
    {

        EnemyController _enemy;

        GameObject _secondaryAmmo;

        string _secondaryAmmoName;

        WingedRockets _wingedRockets;

        RocketController _rocketController;

        int _rocketIndex = 0;

        bool _stopSecondaryFire;

        public EnemyFireSecondary(EnemyController enemyController, GameObject secondaryAmmo)
        {

            _enemy = enemyController;

            _secondaryAmmo = secondaryAmmo;

            _secondaryAmmoName = secondaryAmmo.gameObject.name;

            _wingedRockets = _enemy.gameObject.GetComponentInChildren<WingedRockets>();

            _rocketIndex = 0;

        }


        public void FixedTick()
        {

            switch (_secondaryAmmoName)
            {

                case "WingedBasicRocket":

                    GameObject rocket = _wingedRockets.GetWingedBasicRocket(_rocketIndex);

                    _rocketController = rocket.gameObject.GetComponent<RocketController>();

                    _rocketController.PrepareToFire();

                    _rocketIndex += 1;

                    if (_rocketIndex >= 6)
                    {

                        _enemy.StopSecondaryFire = true;

                    }

                    break;

            }

        }
    }
}

