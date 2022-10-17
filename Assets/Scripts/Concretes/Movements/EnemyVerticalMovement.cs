using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WARDY.Abstracts.Controllers;

namespace WARDY.Movements
{
    public class EnemyVerticalMovement
    {

        #region Component

        EnemyController _enemyController;

        Rigidbody _rigidbody;

        #endregion

        #region Private
        float _verticalSpeed;
        float _abovePoint = 4.5f;  //KevB's upper limit for vertical movement

        float _belowPoint = -4.5f;  //KevB's lower limit for vertical movement

        float _midPoint = 0f;

        float _midAbove = 1.5f;
        float _midBelow = -1.5f;

        float _targetPointAbove = 0.75f;
        float _targetPointBelow = -0.75f;

        string _verticalMovementDirection = "";//KevB's first movement direction
        string _movementType;

        #endregion

        #region Constructer

        public EnemyVerticalMovement(EnemyController enemyController)
        {

            _enemyController = enemyController;

            _rigidbody = _enemyController.GetRigidbody;

            _verticalSpeed = _enemyController.VerticalSpeed;



            if (_enemyController.transform.position.y == _abovePoint)
            {

                _verticalMovementDirection = "down";
                _movementType = "UpToDown";

            }

            else if (_enemyController.transform.position.y == _belowPoint)
            {

                _verticalMovementDirection = "up";
                _movementType = "DownToUp";

            }

            else if (_enemyController.transform.position.y == _midPoint)
            {


                _verticalMovementDirection = "middown";

            }

            else if (_enemyController.transform.position.y == _midAbove)
            {


                _verticalMovementDirection = "midAboveDown";

            }

            else if (_enemyController.transform.position.y == _midBelow)
            {


                _verticalMovementDirection = "midBelowUp";

            }

        }

        #endregion

        public void FixedTick(Vector3 enemyPosition)
        {

            switch (_verticalMovementDirection)
            {
                case "up":

                    _rigidbody.transform.Translate(new Vector3(0, (_verticalSpeed), 0));
                    if (_movementType == "DownToUp")
                    {

                        if (_enemyController.transform.position.y >= _targetPointBelow)
                        {
                            _verticalMovementDirection = "down";
                        }
                    }
                    else if (_movementType == "UpToDown")
                    {

                        if (_enemyController.transform.position.y >= _abovePoint)
                        {
                            _verticalMovementDirection = "down";
                        }
                    }



                    break;

                case "down":

                    _rigidbody.transform.Translate(new Vector3(0, -(_verticalSpeed), 0));
                    if (_movementType == "DownToUp")
                    {

                        if (_enemyController.transform.position.y <= _belowPoint)
                        {
                            _verticalMovementDirection = "up";
                        }
                    }
                    else if (_movementType == "UpToDown")
                    {

                        if (_enemyController.transform.position.y <= _targetPointAbove)
                        {
                            _verticalMovementDirection = "up";
                        }
                    }
                    break;

                case "middown":
                    _rigidbody.transform.Translate(new Vector3(0, -(_verticalSpeed), 0));

                    if (_enemyController.transform.position.y <= -2f)
                    {
                        _verticalMovementDirection = "midup";
                    }

                    break;

                case "midup":
                    _rigidbody.transform.Translate(new Vector3(0, (_verticalSpeed), 0));

                    if (_enemyController.transform.position.y >= 2f)
                    {
                        _verticalMovementDirection = "middown";
                    }

                    break;

                case "midAboveDown":
                    _rigidbody.transform.Translate(new Vector3(0, -(_verticalSpeed), 0));

                    if (_enemyController.transform.position.y <= -1.5f)
                    {
                        _verticalMovementDirection = "midBelowUp";
                    }

                    break;

                case "midBelowUp":
                    _rigidbody.transform.Translate(new Vector3(0, (_verticalSpeed), 0));

                    if (_enemyController.transform.position.y >= 1.5f)
                    {
                        _verticalMovementDirection = "midAboveDown";
                    }

                    break;


            }
        }

        #region Kekere Mekere
        /*
        Bu tarlaya bir şinik, kekere mekere ekmişler. Bu tarlaya da bir şinik kekere mekere ekmişler. 
        Bu tarlaya ekilen bir şinik kekere mekereye boz ala boz başlı pis porsuk dadanmış, 
        bu tarlaya ekilen bir şinik kekere mekereye de boz ala boz başlı pis porsuk dadanmış, 
        o tarlaya ekilen bir şinik kekere mekereye dadanan boz ala boz başlı pis porsuk, 
        diğer tarlaya ekilen bir şinik kekere mekereye dadanan boz ala boz başlı pis porsuk'a demiş ki, 
        sen ne zamandan beri bu tarlaya ekilen bir şinik kekere mekereye dadanan boz ala boz başlı pis porsuksun?
        O da ona cevaben;
        Sen ne zaman o tarlaya ekilen bir şinik kekere mekereye dadanan boz ala boz başlı pis porsuksan,
        ben de o zamandan beri bu tarlaya ekilen bir şinik kekere mekereye dadanan boz ala boz başlı pis porsuğum demiş.
        */
        #endregion
    }
}

