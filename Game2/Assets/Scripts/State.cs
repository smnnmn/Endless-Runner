using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Condition
{
    START,
    FINISH,
    RESUME
}
public class State : MonoBehaviour
{
    private static Action start;
    private static Action finish;
    private static Action resume;

    private static Dictionary<Condition, UnityEvent> dictionary = new Dictionary<Condition, UnityEvent>();

    public static void Subscribe(Condition condition, UnityAction unityAction)
    {
        UnityEvent unityEvent = new UnityEvent();

        unityEvent.AddListener(unityAction);
        
        switch(condition)
        {
            case Condition.START:
                break;
            case Condition.FINISH:
                break;
            case Condition.RESUME:
                break;
        }
        dictionary.Add(condition, unityEvent);
    }
    public static void Publish(Condition condition)
    {

    }
}
