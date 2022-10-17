using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WARDY.Managers
{
    public class MainMenuManager : MonoBehaviour
    {

        public void OnClickStartGame()
        {

            EventManager.OnStartGame();
            
        }

    }
}

