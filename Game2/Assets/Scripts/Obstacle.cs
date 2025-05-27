using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour , Collidable
{

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(transform.forward * SpeedManager.Instance.Speed * Time.deltaTime);
    }

    public void Activate()
    {
        gameObject.SetActive(false);
    }

}
