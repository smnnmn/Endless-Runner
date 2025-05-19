using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    [SerializeField] float speed;
    public int roadIndex;
    [SerializeField] GameObject[] prefab;
    // Update is called once per frame
    private void Start()
    {
        int reRoad = Random.Range(0, 2);
        if(reRoad == 1)
        {
            StartCoroutine(ReMove());
        }
    }
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    IEnumerator ReMove()
    {
        yield return new WaitForSeconds(Random.Range(1f, 3f));

        float end = prefab[(roadIndex+ Random.Range(1, 3)) % 2].transform.position.x;

        Vector3 endVec = new Vector3(end, transform.position.y, transform.position.z);

        while (transform.position.x + 0.1f < end || transform.position.x - 0.1f > end)
        {
            transform.position = Vector3.Lerp(transform.position,endVec, 0.5f);
        }
        Debug.Log("³¡");

    }
}
