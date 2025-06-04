using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpeedManager : Singleton<SpeedManager>
{
    [SerializeField] float speed = 30.0f;
    [SerializeField] float limitSpeed = 60.0f;

    [SerializeField] float initializeSpeed;

    public float Speed { get { return speed; } }

    public float InitializeSpeed { get { return initializeSpeed; } }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        initializeSpeed = speed;

        State.Subscribe(Condition.START, Execute);
        State.Subscribe(Condition.FINISH, Release);
    }
    void Execute()
    {
        StartCoroutine(Increase());
    }
    private void Release()
    {
        StopAllCoroutines();
    }
    private void Start()
    {
    }
    IEnumerator Increase()
    {
        while(speed < limitSpeed)
        {
            yield return new WaitForSeconds(0.533f);
            speed += 0.5f;
        }
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        speed = 30;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;

        State.Unsubscribe(Condition.START, Execute);
        State.Unsubscribe(Condition.FINISH, Release);
    }
}
