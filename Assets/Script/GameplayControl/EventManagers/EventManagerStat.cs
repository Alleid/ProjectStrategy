using UnityEngine;
using UnityEngine.Events;

public class EventManagerStat
{
    private static EventManagerStat eventManagerStat;

    private EventManagerStat() { }

    private static object syncRoot = new Object();

    public static EventManagerStat GetEventManagerStat()
    {
        if (eventManagerStat == null)
        {
            lock (syncRoot)
            {
                eventManagerStat = new EventManagerStat();

            }
        }
        return eventManagerStat;
    }

    public static event UnityAction<IBuff> BuffStat;

    public static void OnBuffStat(IBuff buff) => BuffStat?.Invoke(buff);

}

