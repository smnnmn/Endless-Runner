using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour , Collidable
{
    [SerializeField] float speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }

    public void Activate()
    {
        gameObject.SetActive(false);
    }

}
