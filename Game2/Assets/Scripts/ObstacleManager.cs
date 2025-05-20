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

            // ���� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� �ִ� �� Ȯ���մϴ�.
            while (obstacles[random].activeSelf)
            {

                // ���� �ε����� �ִ� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� ������
                // random ������ ���� +1�� �ؼ� �ٽ� �˻��մϴ�.

                random = (random + 1) % obstacles.Count;
            }
            obstacles[random].transform.position = transforms[Random.Range(0, transforms.Length)].position;

            obstacles[random].SetActive(true);

            yield return new WaitForSeconds(5f);

        }

    }
}
