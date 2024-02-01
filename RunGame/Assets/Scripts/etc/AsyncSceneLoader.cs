using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public enum SceneID
{
    TITLE,
    GAME,
}

public class AsyncSceneLoader : Singleton<AsyncSceneLoader>
{
    [SerializeField] float time;
    [SerializeField] Image fadeImage;

    public IEnumerator FadeIn()
    {
        Color color = fadeImage.color;
        color.a = 1.0f;

        fadeImage.gameObject.SetActive(true);

        while(color.a > 0f)
        {
            color.a -= Time.deltaTime;

            fadeImage.color = color;

            yield return null;
        }

        fadeImage.gameObject.SetActive(false);
    }

    public IEnumerator AsyncLoad(SceneID sceneID)
    {
        fadeImage.gameObject.SetActive(true);

        // 강제 형변환
        AsyncOperation asyncoperation = SceneManager.LoadSceneAsync((int)sceneID);

        // bool allowSceneActivation : 장면이 준비되는 즉시 장면을 활성화 시킬 것 인지 허용하는 기능입니다.
        asyncoperation.allowSceneActivation = false;

        Color color = fadeImage.color;

        color.a = 0f;

        // bool isDone : 해당 동작이 준비되었는 지 판단하는 기능입니다.
        while(asyncoperation.isDone == false)
        {
            color.a += Time.unscaledDeltaTime;

            fadeImage.color= color;

            // float progress : 작업의 진행 정도를 0 ~ 1 사이의 값으로 확인하는 기능입니다.
            if (asyncoperation.progress >= 0.9f)
            {
                // fake loading

                // color의 alpha 값을 1.0f로 Lerp 함수를 통해서 올려주세요.
                color.a = Mathf.Lerp(color.a, 1.0f, Time.unscaledDeltaTime);

                fadeImage.color = color;

                // 알파값이 1.0보다 크거나 같다면
                if (color.a >= 1.0f)
                {
                    // allowSceneActivation을 활성화합니다.
                    asyncoperation.allowSceneActivation = true;

                    yield break;
                }
            }
            yield return null;
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(FadeIn());
    }


    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
