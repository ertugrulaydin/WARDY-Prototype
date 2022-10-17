using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WARDY.Controllers;
using WARDY.Walls;
using WARDY.Abstracts.Interfaces;



namespace WARDY.Managers
{
    public class PlayerChangeManager : MonoBehaviour
    {

        #region SerializeField

        [SerializeField] PlayerController _player;

        #endregion


        #region Private

        int _playerChange = 3;

        float _damage;

        #endregion

        #region Properties

        public int PlayerChange => _playerChange;

        #endregion




        private void OnEnable()
        {
            EventManager.ReducePlayerChange += ReducePlayerChange;
            EventManager.EnemyDestroyedByWall += ReducePlayerChange;
        }


        private void ReducePlayerChange(GameObject obj)
        {

            if (!_player.IsImmune)
            {

                if (obj.GetComponent<CellFloorWall>() != null)
                {

                    _playerChange -= 1;

                    _player.SetPlayerPositionAfterReduceChange();

                    Time.timeScale = 0;

                    StartCoroutine("SetTimeScale");

                }

                else if (obj.GetComponent<IBullet>() != null)
                {

                    _damage = obj.GetComponent<BasicBullet>().Damage;

                    _player.Damage(_damage);

                    if (_player.Health <= 0)
                    {

                        _playerChange -= 1;

                        _player.SetPlayerPositionAfterReduceChange();

                        Time.timeScale = 0;

                        StartCoroutine("SetTimeScale");

                    }

                }

                else
                {

                    _playerChange -= 1;

                    _player.Health = _player.TotalHealth;

                    Debug.Log(_playerChange);

                }

            }

        }

        private void ReducePlayerChange()
        {

            _playerChange -= 1;

            Debug.Log(_playerChange);

        }

        IEnumerator SetTimeScale()
        {

            //player will be immune when its position get reset PlayerImmuneForASecond = true

            _player.IsImmune = true;

            yield return new WaitForSecondsRealtime(1.25f);

            Time.timeScale = 1;

            _player.Health = _player.TotalHealth;

        }


        private void OnDisable()
        {

            EventManager.ReducePlayerChange -= ReducePlayerChange;

            EventManager.EnemyDestroyedByWall -= ReducePlayerChange;

        }
    }
}

