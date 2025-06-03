using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour, Collidable
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
    private void OnEnable()
    {
        State.Subscribe(Condition.FINISH, Release);
    }
    void Release()
    {
        StopAllCoroutines();
    }
    private void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            prefabs[i] = vehicleSpanwer.InsPosition[i];
        }
        int reRoad = Random.Range(1, 2);
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
        yield return new WaitForSeconds(Random.Range(2.5f, 2.75f));

        int random = Random.Range(1, 3);
        end = prefabs[(roadIndex + random) % 3].transform.localPosition.x;

        // roadIndex = 0, 1, 2
        // 1, 2를 더하고 % 3를 하면
        // 0은 1 ,2 최종적으로 1, 2
        // 1은 2, 3 최종적으로 2, 0
        // 2는 3, 4 최종적으로 0, 1


        // Vector3 endVec = new Vector3(end, transform.position.y, transform.position.z);

        while (transform.position.x + 0.1f < end || transform.position.x - 0.1f > end)
        {
            transform.position = new Vector3(Mathf.Lerp(transform.position.x,end,0.2f),transform.position.y,transform.position.z);

            // transform.position = Vector3.Lerp(transform.position,endVec, 0.2f);
            yield return null;
        }
        Debug.Log("끝");

    }
    public void Activate()
    {
        Destroy(gameObject);
    }
    void OnDisable()
    {
        State.Unsubscribe(Condition.FINISH, Release);

    }
}
