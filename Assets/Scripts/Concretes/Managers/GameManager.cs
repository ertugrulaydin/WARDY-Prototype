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

        [SerializeField] PlayerChangeManager _playerChangeManager;

        #endregion

        #region Private
        float _coroutineTime;

        #endregion

        #region Properties
        public float CoroutineTime { get => _coroutineTime; set => _coroutineTime = value; }
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

        }


        private void OnEnable()
        {
            EventManager.StartGame += LoadLevel;
        }

        private void Update()
        {
            if (_playerChangeManager.PlayerChange <= 0)
            {
                Time.timeScale = 0;
            }
        }

        private void LoadLevel()
        {

            SceneManager.LoadScene(1);
        }

        private void OnDisable()
        {
            EventManager.StartGame -= LoadLevel;
        }


        IEnumerator NonMonoBehaviourCoroutine(CoroutineDelegate methodToCall)
        {

            yield return new WaitForSecondsRealtime(_coroutineTime);

            methodToCall();
        }
    }
}

