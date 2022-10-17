using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WARDY.Controllers;
using WARDY.Abstracts.Controllers;

namespace WARDY.Movements
{
    public class BossFirstMovement
    {

        #region SerializeField

        [SerializeField] GameObject _player;

        #endregion


        #region Private
        BossController _boss;

        Vector3 _bossPosition;

        float _offset = 17.5f;

        float _speed;



        #endregion


        #region Constructor

        public BossFirstMovement(BossController boss, GameObject player)
        {

            _boss = boss;
            _player = player;
            _speed = _boss.FirstMoveSpeed;


        }

        #endregion


        public void FixedTick()
        {

            if (_boss.transform.position.x - _offset >= _player.transform.position.x)
            {

                _boss.transform.position = _boss.transform.position - new Vector3(_speed, 0, 0);

                _bossPosition = _boss.transform.position;

            }

            else
            {

                _boss.UpdatePositionAfterFirstMovement(_bossPosition);

                _boss.FirstMoveCompleted = true;

            }
        }
    }
}

