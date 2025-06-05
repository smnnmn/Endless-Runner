using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneryManager : MonoBehaviour
{
    [SerializeField] Image screenImage;

    private void OnEnable()
    {
        State.Subscribe(Condition.RESUME, Load);
    }
    void Load()
    {
        StartCoroutine(Coroutine());
    }
    public IEnumerator Coroutine()
    {
        screenImage.gameObject.SetActive(true);

        // <asyncOperation.allowSceneActivation>
        // ����� �غ�� ��� ����� Ȱ��ȭ�Ǵ� ���� ����ϴ� �����Դϴ�.
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);

        asyncOperation.allowSceneActivation = false;

        Color color = screenImage.color;

        color.a = 0f;

        // <asyncOperation.isDone>
        // �ش� ������ �Ϸ�Ǿ����� ��Ÿ���� �����Դϴ�. (�б� ����)
        while (asyncOperation.isDone == false)
        {
            color.a += Time.deltaTime;

            screenImage.color = color;

            // <asyncOperation.progress>
            // �۾��� ���� ���¸� ���³��� �����Դϴ�. (�б� ����)
            if (asyncOperation.progress >= 0.9f)
            {
                color.a = Mathf.Lerp(color.a, 1f, Time.deltaTime);

                screenImage.color = color;

                if (color.a >= 1.0f)
                {
                    asyncOperation.allowSceneActivation = true;

                    yield break;
                }
            }

            yield return null;
        }
    }
    private void OnDisable()
    {
        State.Unsubscribe(Condition.RESUME, Load);
    }
}
