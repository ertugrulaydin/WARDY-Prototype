using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WARDY.Controllers.EnemyControllers;


namespace WARDY.Movements
{
    public class BossKevVerticalMovement
    {
        #region Private Field
        BossKev _bossKev;

        Vector3 _firstPosition;

        Vector3 _secondPosition;

        Vector3 _targetVerticalPosition;

        float _lerpValue;

        string _direction = "down";


        #endregion



        public BossKevVerticalMovement(BossKev bosskev)
        {

            _bossKev = bosskev;

            //_firstPosition = _bossKev.transform.position;

            //_secondPosition = _firstPosition - new Vector3(0, 4, 0);

            _lerpValue = 0;



        }

        public void FixedTick()
        {

            if (_direction.Equals("down"))
            {
                _bossKev.transform.position = Vector3.Lerp(_firstPosition, _secondPosition, _lerpValue);
                if (_bossKev.transform.position.y == _secondPosition.y)
                {
                    _direction = "up";
                    _lerpValue = 0;
                }
            }

            else if (_direction.Equals("up"))
            {
                _bossKev.transform.position = Vector3.Lerp(_secondPosition, _firstPosition, _lerpValue);
                if (_bossKev.transform.position.y == _firstPosition.y)
                {
                    _direction = "down";
                    _lerpValue = 0;
                }
            }


            _lerpValue += 0.01f;

        }

        public void SetFirstPos(Vector3 firstPosition)
        {

            _firstPosition = firstPosition;

            _secondPosition = _firstPosition - new Vector3(0, 4.5f, 0);

        }

    }
}

