using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : Singleton<SpeedManager>
{
    [SerializeField] float speed = 30.0f;
    [SerializeField] float limitSpeed = 60.0f;

    public float Speed { get { return speed; } }

    private void OnEnable()
    {
        State.Subscribe(Condition.START, Execute);
    }
    void Execute()
    {
        StartCoroutine(Increase());
    }
    private void Start()
    {
    }
    IEnumerator Increase()
    {
        while(speed < limitSpeed)
        {
            yield return new WaitForSeconds(5f);
            speed += 2.5f;
        }
    }
    private void OnDisable()
    {
        State.Unsubscribe(Condition.START, Execute);
    }
}
