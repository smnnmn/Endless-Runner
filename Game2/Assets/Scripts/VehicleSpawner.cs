using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] Transform[] InsPosition;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InsVehicle());
    }
    Transform SetPosition()
    {
        return InsPosition[Random.Range(0, InsPosition.Length)];
    }
    IEnumerator InsVehicle()
    {
        while(true)
        {
            // Instantiate(prefab, transform.position, transform.rotation);
            Instantiate(prefab, SetPosition());
            Debug.Log("»ý¼º");
            yield return new WaitForSeconds(Random.Range(2, 6));
        }
    
    }
}
