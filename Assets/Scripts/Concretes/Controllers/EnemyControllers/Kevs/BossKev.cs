using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WARDY.Movements;
using WARDY.Abstracts.Interfaces;


namespace WARDY.Controllers.EnemyControllers
{
    public class BossKev : MonoBehaviour, IBoss
    {

        #region Private Field

        BossKevVerticalMovement _bossKevVerticalMovement;

        BossKevHorizontalMovement _bossKevHorizontalMovement;

        bool _verticalMove = true;

        bool _horizontalMove = false;

        float _actionTime;

        float _timeCounter = 0;

        int _sendParameterCount = 0;

        int _verticalMovementCount = 1;

        int _setLerpCount = 0;

        Vector3 _bossHorizontalMoveStartPos;
        Vector3 _bossHorizontalMoveTargetPlayerPos;

        #endregion

        #region SerializeField

        [SerializeField] PlayerController _playerController;

        #endregion




        private void Start()
        {

            _bossKevVerticalMovement = new BossKevVerticalMovement(this);


            if (_playerController != null)
            {

                _bossKevHorizontalMovement = new BossKevHorizontalMovement(this);

            }
            else
            {

                Debug.Log("Player Controller is empty. Add Player Controller from inspector");

            }

            _actionTime = Random.Range(3, 5);

        }


        private void FixedUpdate()
        {
            _timeCounter += Time.deltaTime;

            BossAction();

        }

        public void BossAction()
        {

            if (_verticalMove)
            {

                _sendParameterCount = 0;

                //Debug.Log("action time: " + _actionTime + " time counter: " + _timeCounter);

                if (_timeCounter >= _actionTime)
                {


                    _verticalMove = false;

                    _horizontalMove = true;

                    _bossKevHorizontalMovement.SetActionCompletedFalse();

                    _verticalMovementCount += 1;

                    _setLerpCount = 0;
                }


                else
                {
                    _bossKevVerticalMovement.FixedTick();


                    if (_verticalMovementCount % 6 == 0 && _setLerpCount == 0)
                    {

                        _bossKevHorizontalMovement.SetLerp = 0.0015f;

                        _setLerpCount = 1;
                    }
                }

            }

            if (_horizontalMove)
            {


                if (_sendParameterCount == 0)
                {

                    _bossHorizontalMoveStartPos = transform.position;
                    _bossHorizontalMoveTargetPlayerPos = _playerController.transform.position;

                    _sendParameterCount = 1;

                }


                if (!_bossKevHorizontalMovement.ActionCompleted)
                {

                    _bossKevHorizontalMovement.FixedTick(_bossHorizontalMoveStartPos, _bossHorizontalMoveTargetPlayerPos);

                }

                else
                {

                    _timeCounter = 0f;

                    _actionTime = Random.Range(3, 5);

                    _verticalMove = true;

                    _horizontalMove = false;

                }
            }

        }

    }
}

