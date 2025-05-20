using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    [SerializeField] float speed;
    public int roadIndex;
    private GameObject[] prefabs = new GameObject[3];

    [SerializeField] float end;

    VehicleSpawner vehicleSpanwer;
    // Update is called once per frame
    private void Awake()
    {
        vehicleSpanwer = FindObjectOfType<VehicleSpawner>();
    }
    private void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            prefabs[i] = vehicleSpanwer.InsPosition[i];
        }
        int reRoad = Random.Range(0, 2);
        if(reRoad >= 1)
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

        end = prefabs[(roadIndex + Random.Range(1, 3)) % 2].transform.localPosition.x;

        // Vector3 endVec = new Vector3(end, transform.position.y, transform.position.z);

        while (transform.position.x + 0.1f < end || transform.position.x - 0.1f > end)
        {
            transform.position = new Vector3(Mathf.Lerp(transform.position.x,end,0.2f),transform.position.y,transform.position.z);

            // transform.position = Vector3.Lerp(transform.position,endVec, 0.2f);
            yield return null;
        }
        Debug.Log("³¡");

    }
}
