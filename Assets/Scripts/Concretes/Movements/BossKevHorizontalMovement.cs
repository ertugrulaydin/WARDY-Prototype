using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WARDY.Controllers.EnemyControllers;


namespace WARDY.Movements
{
    public class BossKevHorizontalMovement
    {
        #region Private Field
        BossKev _bossKev;


        Vector3 _targetHorizontalPosition;

        float _lerpValue;

        float _lerp = 0.005f;

        string _direction = "forward";

        bool _actionCompleted = false;

        #endregion

        #region Properties

        public bool ActionCompleted => _actionCompleted;

        public float SetLerp { get => _lerp; set => _lerp = _lerp + value; }

        #endregion

        public BossKevHorizontalMovement(BossKev bossKev)
        {
            _bossKev = bossKev;

            _lerpValue = 0;
        }

        public void FixedTick(Vector3 firstPosition, Vector3 playerPosition)
        {

            _targetHorizontalPosition = new Vector3(playerPosition.x, firstPosition.y, 0);

            //Debug.Log(firstPosition);

            if (!_actionCompleted)
            {
                if (_direction.Equals("forward"))
                {
                    _bossKev.transform.position = Vector3.Lerp(firstPosition, _targetHorizontalPosition, _lerpValue);

                    if (_bossKev.transform.position.x == _targetHorizontalPosition.x)
                    {
                        _direction = "backward";
                        _lerpValue = 0;
                    }
                }

                else if (_direction.Equals("backward"))
                {

                    _bossKev.transform.position = Vector3.Lerp(_targetHorizontalPosition, firstPosition, _lerpValue);

                    if (_bossKev.transform.position.x == firstPosition.x)
                    {


                        _direction = "forward";
                        _lerpValue = 0;

                        _actionCompleted = true;

                    }
                }


            }

            _lerpValue += _lerp;

            //Debug.Log(_lerp);
        }

        public void SetActionCompletedFalse()
        {
            _actionCompleted = false;

        }

    }
}

