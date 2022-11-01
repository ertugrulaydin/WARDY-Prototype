using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using WARDY.Abstracts.Controllers;
using UnityEngine.UI;
using System;

namespace WARDY.Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text _gameScoreText;

        [SerializeField] private GameObject _gameOverObject;

        [SerializeField] private List<RawImage> _playerChangesImages;

        private int _score = 0;




        private void Start()
        {

            EventManager.EnemyGetHit += GameScore;

            EventManager.GameOver += IsGameOver;

        }




        private void GameScore(EnemyController enemyController)
        {
            _score = (int)(_score + 100);

            _gameScoreText.text = _score.ToString();
        }

        private void IsGameOver()
        {

            _gameOverObject.SetActive(true);

        }

        public void OnClickTryAgain()
        {
            Time.timeScale = 1;

            GameManager.Instance.LoadLevel();

        }

        public void OnClickMainMenu()
        {
            GameManager.Instance.LoadLevel(0);
        }

        public void PlayerChangeImages(int index)
        {

            _playerChangesImages[index].enabled = false;

        }


        private void OnDisable()
        {
            EventManager.EnemyGetHit -= GameScore;
            EventManager.GameOver -= IsGameOver;
        }
    }
}


