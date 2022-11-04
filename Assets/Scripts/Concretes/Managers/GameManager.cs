using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static WARDY.Managers.EnemyHealthUIManager;

namespace WARDY.Managers
{
    public class GameManager : MonoBehaviour
    {

        #region Instance
        public static GameManager Instance { get; private set; }

        #endregion


        #region SerializeField


        #endregion

        #region Private

        CoroutineDelegate _methodToCall;
        float _timer;

        float _count;

        bool _startTimer;

        bool _timerComplete;

        #endregion



        private void Awake()
        {

            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);

            }
            else
            {
                Destroy(this.gameObject);
            }

            //Debug.Log("try againden sonra timescale çalışmıyor");

        }
        private void Start()
        {

            _count = 0;

            _startTimer = false;

        }

        private void Update()
        {

            GameTimer();

        }


        private void OnEnable()
        {
            EventManager.StartGame += LoadLevel;
        }



        public void LoadLevel(int index)
        {

            SceneManager.LoadScene(index);
        }

        public void LoadLevel()
        {

            SceneManager.LoadScene(1);

        }

        private void OnDisable()
        {
            EventManager.StartGame -= LoadLevel;
        }


        public void StartTimer(float timer, CoroutineDelegate methodToCall)
        {

            _methodToCall = methodToCall;

            _timer = timer;

            _count = 0;

            _startTimer = true;

            _timerComplete = false;

        }

        private void GameTimer()
        {

            if (_startTimer)
            {

                _count += Time.deltaTime;

                if (_count >= _timer)
                {

                    _startTimer = false;

                    _timerComplete = true;

                    _count = 0;

                }

            }

            if (_timerComplete)
            {

                _timerComplete = false;

                _methodToCall();

            }
        }
    }
}

