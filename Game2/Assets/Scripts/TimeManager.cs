using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField] Text timeText;

    [SerializeField] float time;

    [SerializeField] int minute;
    [SerializeField] int second;
    [SerializeField] int millisecond;

    private void Start()
    {
        StartCoroutine(Measure());
    }
    public IEnumerator Measure()
    {
        while(true)
        {
            time += Time.deltaTime;

            minute = (int)time / 60;
            second = (int)time % 60;
            millisecond = (int)(time * 100) % 100;

            timeText.text = string.Format("{0:D2} : {1:D2} : {2:D2}", minute, second, millisecond);

            yield return null;
        }
    }
}
