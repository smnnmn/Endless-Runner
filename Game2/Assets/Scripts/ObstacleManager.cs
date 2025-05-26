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
    private void Start()
    {
        obstacles.Capacity = 10;

        Create();

        StartCoroutine(ActiveObstacle());
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

                // ���� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� �ִ� �� Ȯ���մϴ�.
                while (obstacles[random].activeSelf)
                {

                    // ���� ����Ʈ�� �ִ� ��� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� �ִ� �� Ȯ���մϴ�.
                    if (ExamineActive())
                    {
                        // ��� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� �ִٸ� ���� ������Ʈ�� ����
                        // ������ ���� obstacles ����Ʈ�� �־��ݴϴ�.
                        GameObject clone = Instantiate(Resources.Load<GameObject>(prefabsName[Random.Range(0, prefabsName.Length)]), transform);

                        clone.SetActive(false);

                        obstacles.Add(clone);
                    }

                    // ���� �ε����� �ִ� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� ������
                    // random ������ ���� +1�� �ؼ� �ٽ� �˻��մϴ�.

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
}
