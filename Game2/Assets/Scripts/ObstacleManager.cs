using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] List<GameObject> obstacleList = new List<GameObject>();
    [SerializeField] GameObject[] obstacles;

    private void Start()
    {
        for(int i = 0;i < obstacleList.Count; i++)
        {
            obstacleList[i] = obstacles[Random.Range(0, obstacles.Length)];
            obstacleList[i].SetActive(false);
        }
    }
}
