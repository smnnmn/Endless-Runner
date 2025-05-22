using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    [SerializeField] Texture2D texture2D;
    // Start is called before the first frame update

    private void Awake()
    {
        texture2D = Resources.Load<Texture2D>("Default");
    }
    void Start()
    {
        Cursor.SetCursor(texture2D, Vector2.zero, CursorMode.ForceSoftware);
    }

    void EnableMouse()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    void DisableMouse()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
