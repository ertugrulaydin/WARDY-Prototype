using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace WARDY.Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text _gameScoreText;
        private int _score = 0;


        private void Start()
        {
            EventManager.EnemyGetHit += GameScore;
        }




        private void GameScore()
        {
            _score = (int)(_score + 100);

            _gameScoreText.text = _score.ToString();
        }


        private void OnDisable()
        {
            EventManager.EnemyGetHit -= GameScore;
        }
    }
}


