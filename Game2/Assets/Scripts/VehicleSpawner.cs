using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] prefabs;
    public  GameObject[] InsPosition;

    private int index;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InsVehicle());
    }
    Vector3 SetPosition()
    {
        index = Random.Range(0, InsPosition.Length);
        return InsPosition[index].transform.position;
    }
    IEnumerator InsVehicle()
    {
        while(true)
        {
            // Instantiate(prefab, transform.position, transform.rotation);
            GameObject gameObject = Instantiate(prefabs[Random.Range(0,prefabs.Length)], SetPosition(), Quaternion.Euler(0,180,0));
            gameObject.GetComponent<Vehicle>().roadIndex = index;
            Debug.Log(index);
            yield return new WaitForSeconds(Random.Range(0.75f, 1f));
        }
    
    }
}
