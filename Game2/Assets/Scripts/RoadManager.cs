using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] List<GameObject> roads = new List<GameObject>();
    private float offset = 40.0f;
    // Start is called before the first frame update
    private void OnEnable()
    {
        State.Subscribe(Condition.START, Execute);
        State.Subscribe(Condition.FINISH, Release);
    }
    void Execute()
    {
        StartCoroutine(Coroutine());
    }
    void Release()
    {
        StopAllCoroutines();
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Coroutine()
    {
        while(true)
        {
            for (int i = 0; i < roads.Count; i++)
            {
                roads[i].transform.Translate(SpeedManager.Instance.Speed * Vector3.back * Time.deltaTime);
            }
            yield return null;
        }
    }
    public void InitalizePosition()
    {
        GameObject newRoad = roads[0];
        roads.Remove(newRoad);
        float newZ = roads[roads.Count - 1].transform.position.z + offset;
        newRoad.transform.position = new Vector3(0, 0, newZ);
        roads.Add(newRoad);
    }
    private void OnDisable()
    {
        State.Unsubscribe(Condition.START, Execute);
        State.Unsubscribe(Condition.FINISH, Release);
    }
}
