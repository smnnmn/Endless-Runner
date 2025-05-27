using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    [SerializeField] float speed = 30.0f;

    public float Speed { get { return speed; } }
    private static SpeedManager instance;
    public static SpeedManager Instance
    {
        get { return instance; }
    }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
