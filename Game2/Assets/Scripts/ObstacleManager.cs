using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] int random;

    [SerializeField] int createCount = 5;

    [SerializeField] List<GameObject> obstacles;
    [SerializeField] GameObject[] prefabs;

    [SerializeField] Transform[] transforms;

    private void Start()
    {
        Create();

       // StartCoroutine(ActiveObstacle());
    }
    void Create()
    {
        for (int i = 0; i < createCount; i++)
        {
            GameObject clone = Instantiate(prefabs[Random.Range(0, prefabs.Length)],transform);
            clone.SetActive(false);
            obstacles.Add(clone);
        }
    }
    public IEnumerator ActiveObstacle()
    {
        while(true)
        {

            random = Random.Range(0, obstacles.Count);

            // 현재 게임 오브젝트가 활성화되어 있는 지 확인합니다.
            while (obstacles[random].activeSelf)
            {

                // 현재 인덱스에 있는 게임 오브젝트가 활성화되어 있으면
                // random 변수의 값을 +1을 해서 다시 검색합니다.

                random = (random + 1) % obstacles.Count;
            }
            obstacles[random].transform.position = transforms[Random.Range(0, transforms.Length)].position;

            obstacles[random].SetActive(true);

            yield return new WaitForSeconds(5f);

        }

    }
}
