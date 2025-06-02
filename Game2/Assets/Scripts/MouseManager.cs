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
    private void OnEnable()
    {
        State.Subscribe(Condition.FINISH, EnableMode);
        State.Subscribe(Condition.START, DisableMode);
    }

    void EnableMode()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    void DisableMode()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void OnDisable()
    {
        State.Unsubscribe(Condition.START, DisableMode);
        State.Unsubscribe(Condition.FINISH, EnableMode);
    }
}
