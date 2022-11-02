using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WARDY.Movements;
using WARDY.Abstracts.Interfaces;
using WARDY.Abstracts.Controllers;


namespace WARDY.Controllers.EnemyControllers
{
    public class BossKev : BossController
    {

        #region Private Field

        BossKevVerticalMovement _bossKevVerticalMovement;

        BossKevHorizontalMovement _bossKevHorizontalMovement;

        bool _verticalMove = true;

        bool _horizontalMove = false;

        float _actionTime;

        float _kevBossHealth = 10000f;



        int _sendParameterCount = 0;

        int _verticalMovementCount = 1;

        int _setLerpCount = 0;

        Vector3 _bossHorizontalMoveStartPos;
        Vector3 _bossHorizontalMoveTargetPlayerPos;



        #endregion

        public override void SetDefaultVariables()
        {

            _bossKevVerticalMovement = new BossKevVerticalMovement(this);

            _bossKevHorizontalMovement = new BossKevHorizontalMovement(this);

            _actionTime = Random.Range(10, 15);

            Health = _kevBossHealth;

            fireRate = 1f;

            SubClassCreated();

            _enemyAnimator.speed = 5;

        }

        public override void UpdatePositionAfterFirstMovement(Vector3 updatedPosition)
        {
            _bossKevVerticalMovement.SetFirstPos(updatedPosition);
        }

        public override void BossAction()
        {
            if (_verticalMove)
            {

                _sendParameterCount = 0;

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

                    _actionTime = Random.Range(10, 15);

                    _verticalMove = true;

                    _horizontalMove = false;

                }
            }
        }

    }

}


