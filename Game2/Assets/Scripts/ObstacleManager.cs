using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] int random;

    [SerializeField] int createCount = 5;

    [SerializeField] List<GameObject> obstacles;
    [SerializeField] string[] prefabsName;

    [SerializeField] Transform[] transforms;

    [SerializeField] WaitForSeconds waitForSeconds = new WaitForSeconds(0.6f);

    private void OnEnable()
    {
        State.Subscribe(Condition.START, Execute);
        State.Subscribe(Condition.FINISH, Release);
    }
    void Execute()
    {
        obstacles.Capacity = 10;

        Create();

        StartCoroutine(ActiveObstacle());
    }
    void Release()
    {
        StopAllCoroutines();
    }
    private void Start()
    {

    }
    void Create()
    {
        for (int i = 0; i < createCount; i++)
        {
            GameObject clone = Instantiate(Resources.Load<GameObject>(prefabsName[Random.Range(0, prefabsName.Length)]),transform);
            clone.name = clone.name.Replace("(clone)", "");
            clone.SetActive(false);
            obstacles.Add(clone);
        }
    }
    bool ExamineActive()
    {
        for(int i = 0; i < obstacles.Count; i++)
        {
            if (obstacles[i].activeSelf == false)
            {
                return false;
            }
        }
        return true;
    }
    public IEnumerator ActiveObstacle()
    {
        while(true)
        {
            int type = Random.Range(0, 2);
            
            if(type == 0)
            {
                random = Random.Range(0, obstacles.Count);

                // 현재 게임 오브젝트가 활성화되어 있는 지 확인합니다.
                while (obstacles[random].activeSelf)
                {

                    // 현재 리스트에 있는 모든 게임 오브젝트가 활성화되어 있는 지 확인합니다.
                    if (ExamineActive())
                    {
                        // 모든 게임 오브젝트가 활성화되어 있다면 게임 오브젝트를 새로
                        // 생성한 다음 obstacles 리스트에 넣어줍니다.
                        GameObject clone = Instantiate(Resources.Load<GameObject>(prefabsName[Random.Range(0, prefabsName.Length)]), transform);

                        clone.SetActive(false);

                        obstacles.Add(clone);
                    }

                    // 현재 인덱스에 있는 게임 오브젝트가 활성화되어 있으면
                    // random 변수의 값을 +1을 해서 다시 검색합니다.

                    random = (random + 1) % obstacles.Count;
                }
                obstacles[random].transform.position = transforms[Random.Range(0, transforms.Length)].position;

                obstacles[random].SetActive(true);
            }

            else
            {
                VehicleSpawner vehicleSpawner = FindObjectOfType<VehicleSpawner>();
                vehicleSpawner.InsVehicle();
            }
            yield return CoroutineCache.WaitForSecond(0.5f);

        }

    }
    private void OnDisable()
    {
        State.Unsubscribe(Condition.START, Execute);
        State.Unsubscribe(Condition.FINISH, Release);
    }
}
