using System;
using System.Collections.Generic;
using UnityEngine;


namespace WARDY.Managers
{
    public enum GameEvent
    {

        OnEnemyDestroyed

    }

    public static class EventManager
    {


        private static Dictionary<GameEvent, Action> eventTable
            = new Dictionary<GameEvent, Action>();



        public static void AddHandler(GameEvent gameEvent, Action action)
        {
            Debug.Log("added");
            if (!eventTable.ContainsKey(gameEvent))
            {
                eventTable[gameEvent] = action;
            }
            else
            {

                eventTable[gameEvent] += action;
            }
        }

        public static void RemoveHandler(GameEvent gameEvent, Action action)
        {
            Debug.Log("removed");
            if (eventTable[gameEvent] != null)
            {
                eventTable[gameEvent] -= action;
            }
            if (eventTable[gameEvent] == null)
            {
                eventTable.Remove(gameEvent);
            }
        }

        public static void Broadcast(GameEvent gameEvent)
        {


            if (eventTable[gameEvent] == null)
            {
                Debug.Log(gameEvent);
                eventTable[gameEvent]();
            }



        }

    }
}
