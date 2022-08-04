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
        float _abovePoint;  //KevB's upper limit for vertical movement

        float _belowPoint;   //KevB's lower limit for vertical movement

        string _verticalMovementDirection = "";//KevB's first movement direction

        #endregion

        #region Constructer

        public EnemyVerticalMovement(EnemyController enemyController)
        {

            _enemyController = enemyController;

            NonMonoBehaviourClassAwake();

        }

        #endregion
        private void NonMonoBehaviourClassAwake()
        {

            _rigidbody = _enemyController.GetRigidbody;

            _verticalSpeed = _enemyController.VerticalSpeed;

            _abovePoint = _enemyController.transform.position.y + 1f;

            _belowPoint = _abovePoint - 2f;

            _verticalMovementDirection = "up";



        }
        public void FixedTick(Vector3 enemyPosition)
        {

            switch (_verticalMovementDirection)
            {
                case "up":

                    _rigidbody.transform.Translate(new Vector3(0, (_verticalSpeed), 0));

                    if (_enemyController.transform.position.y >= _abovePoint)
                    {
                        _verticalMovementDirection = "down";
                    }

                    break;

                case "down":

                    _rigidbody.transform.Translate(new Vector3(0, -(_verticalSpeed), 0));

                    if (_enemyController.transform.position.y <= _belowPoint)
                    {
                        _verticalMovementDirection = "up";
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

