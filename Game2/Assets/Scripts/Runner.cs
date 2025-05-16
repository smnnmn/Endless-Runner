using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    public enum RoadLine
    {
        LEFT = -1,
        MIDDLE,
        RIGHT,
    }
    [SerializeField] RoadLine roadLine;

    Rigidbody rigidBody;
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
        OnMove();
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
    void OnMove()
    {
        rigidBody.position = new Vector3(4 * (int)roadLine, 0, 0);
    }
}
