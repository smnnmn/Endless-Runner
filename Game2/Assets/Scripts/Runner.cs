using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RoadLine
{
    LEFT = -1,
    MIDDLE,
    RIGHT,
}

public class Runner : MonoBehaviour
{

    [SerializeField] RoadLine roadLine;
    Rigidbody rigidBody;
    
    [SerializeField] float positionX = 4;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        roadLine = RoadLine.MIDDLE;
    }

    // Update is called once per frame
    void Update()
    {
        Keyboard();
        Move();
        Debug.Log(roadLine);
    }
    void Keyboard()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            roadLine--;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            roadLine++;
        }
        roadLine = (RoadLine)Mathf.Clamp((int)roadLine, -1, 1);
    }
    void Move()
    {
        rigidBody.position = new Vector3(positionX * (int)roadLine, 0, 0);
    }
}
