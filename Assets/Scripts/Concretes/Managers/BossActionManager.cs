using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WARDY.Abstracts.Controllers;

namespace WARDY.Managers
{
    public class BossActionManager : MonoBehaviour
    {

        #region SerializeField

        [SerializeField] GameObject _boss;

        [SerializeField] GameObject _playerController;

        #endregion

        private void OnEnable()
        {

            EventManager.BossAction += ActivateBoss;

        }


        private void ActivateBoss()
        {

            _boss.SetActive(true);
            _boss.GetComponent<EnemyController>().SetDefaultVariables();
            _boss.transform.position = new Vector3(_playerController.transform.position.x + 22.5f, 2.25f, 0);
            EventManager.BossAction -= ActivateBoss;

        }

        private void OnDisable()
        {

        }

    }
}

