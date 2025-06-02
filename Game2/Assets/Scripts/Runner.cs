using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RoadLine
{
    LEFT = -1,
    MIDDLE = 0,
    RIGHT = 1
}

public class Runner : MonoBehaviour
{
    [SerializeField] RoadLine roadLine;
    [SerializeField] Rigidbody rigidBody;

    [SerializeField] Animator animator;
    [SerializeField] float positionX = 4;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        State.Subscribe(Condition.FINISH, Die);

        State.Subscribe(Condition.START, InputSystem);
        State.Subscribe(Condition.START, StateTransition);
    }

    public void InputSystem()
    {
        StartCoroutine(Coroutine());
    }

    private void FixedUpdate()
    {
        Move();
    }
    private void OnTriggerEnter(Collider other)
    {
        Obstacle obstacle = other.GetComponent<Obstacle>();
        Vehicle vehicle = other.GetComponent<Vehicle>();

        if(obstacle != null)
        {
            State.Publish(Condition.FINISH);
        }
        else if(vehicle != null)
        {
            State.Publish(Condition.FINISH);
        }
    }
    void Die()
    {
        animator.Play("Die");
    }
    IEnumerator Coroutine()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (roadLine != RoadLine.LEFT)
                {
                    roadLine--;

                    animator.Play("Left Avoid");
                }
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (roadLine != RoadLine.RIGHT)
                {
                    roadLine++;

                    animator.Play("Right Avoid");
                }
            }

            yield return null;
        }
    }

    void Move()
    {
        rigidBody.position = Vector3.Lerp
        (
            rigidBody.position,
            new Vector3(positionX * (int)roadLine, 0, 0),
            SpeedManager.Instance.Speed * Time.deltaTime
        );
    }

    public void StateTransition()
    {
        animator.SetTrigger("Start");
    }

    private void OnDisable()
    {
        State.Unsubscribe(Condition.FINISH, Die);

        State.Unsubscribe(Condition.START, InputSystem);
        State.Unsubscribe(Condition.START, StateTransition);
    }
}