using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WARDY.Abstracts.Controllers;


namespace WARDY.Managers
{
    public class EnemyHealthUIManager
    {

        public delegate void CoroutineDelegate();

        public CoroutineDelegate methodToCall;
        private TMP_Text enemyHealthUI;

        EnemyController _enemyController;
        private float _enemyHealth;

        private float _maxHealth;

        RawImage _healtBarImage;

        float _coroutineTime = 0.25f;

        Vector3 _panelScaleVector;

        Vector3 _panelDefaultScaleVector;

        Vector3 _objectScaleVector;

        Vector3 _objectDefaultScaleVector;






        public EnemyHealthUIManager(EnemyController enemyController)
        {

            _enemyController = enemyController;

            _enemyHealth = _enemyController.Health;

            _maxHealth = _enemyController.Health;

            enemyHealthUI = _enemyController.EnemyHealthUI;

            _healtBarImage = _enemyController.HealthBarImage;

            _enemyController.EnemyHealthUI.text = _enemyHealth.ToString();

            _enemyController.HealthBarImage.rectTransform.localScale = new Vector3(1, 1, 1);

            if (_enemyController.IsBoos)
            {

                _panelScaleVector = new Vector3(1f, 0.5f, 1f);

                _panelDefaultScaleVector = new Vector3(0.5f, 0.25f, 1f);

                _objectScaleVector = new Vector3(1, 1, 1);

                _objectDefaultScaleVector = new Vector3(1, 1, 1);

            }

            else
            {

                _panelScaleVector = new Vector3(2.5f, 2.5f, 1f);

                _panelDefaultScaleVector = new Vector3(1f, 1f, 1f);

                _objectScaleVector = new Vector3(1.25f, 1.25f, 1.25f);

                _objectDefaultScaleVector = new Vector3(1, 1, 1);

            }

            EventManager.EnemyGetHit += SetEnemyHealthUI;

            methodToCall = SetHealthUICanvasSize;

        }


        private void SetEnemyHealthUI(EnemyController enemyController)
        {

            _enemyController = enemyController;

            _enemyHealth = enemyController.Health;

            _enemyController.EnemyHealthUI.text = _enemyHealth.ToString();

            _enemyController.HealthBarImage.rectTransform.localScale = new Vector3((1 / _maxHealth) * _enemyHealth, 1, 1);

            _enemyController.HealthPanel.transform.localScale = _panelScaleVector;

            //Debug.Log(_panelScaleVector);

            _enemyController.gameObject.transform.GetChild(1).transform.localScale = _objectScaleVector;

            GameManager.Instance.CoroutineTime = _coroutineTime;

            GameManager.Instance.StartCoroutine("NonMonoBehaviourCoroutine", methodToCall);

        }

        void SetHealthUICanvasSize()
        {

            _enemyController.HealthPanel.transform.localScale = _panelDefaultScaleVector;

            //Debug.Log("def: " + _panelDefaultScaleVector);

            _enemyController.gameObject.transform.GetChild(1).transform.localScale = _objectDefaultScaleVector;

        }

        private void OnDisable()
        {
            EventManager.EnemyGetHit -= SetEnemyHealthUI;
        }


    }
}

