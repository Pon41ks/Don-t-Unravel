using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager 
{
    public static UnityEvent OnCoinColected = new UnityEvent();
    public static void SendCoinColected()
    {
        OnCoinColected.Invoke();
    }
    
}
