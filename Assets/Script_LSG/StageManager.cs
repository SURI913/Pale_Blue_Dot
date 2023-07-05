using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    private string ChangeScene;

    public Image fadeImage; // 페이드 아웃에 사용할 이미지
    public float fadeDuration = 1f; // 페이드 아웃 지속 시간

    private float startAlpha = 0f; // 초기 알파 값
    private float targetAlpha = 1f; // 목표 알파 값

    private void Start()
    {
        //SceneManager.LoadScene("SettingUI", LoadSceneMode.Additive);
        // 초기 알파 값 설정
        if(fadeImage != null!)
        {
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, startAlpha);
            fadeImage.gameObject.SetActive(false);
        }
    }

    IEnumerator SceneLoadFade()
    {
        yield return new WaitForSecondsRealtime(1.0f);
        // 페이드 인 아웃 스크립트
        if(fadeImage != null!){
            fadeImage.gameObject.SetActive(true);
            float elapsedTime = 0f;
            while (elapsedTime < fadeDuration)
            {
                // 시간에 따라 알파 값을 조절하여 페이드 아웃 효과 생성
                float alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);

                // 이미지의 알파 값 설정
                Color fadeColor = fadeImage.color;
                fadeColor.a = alpha;
                fadeImage.color = fadeColor;

                elapsedTime += Time.deltaTime;
                yield return null;
            }

        }
        else
        {
            Debug.Log("페이아웃없이 씬 생성");
        }

        SceneManager.LoadScene(ChangeScene);

    }

    public void SceneLoadStage(string sceneName)
    {
        ChangeScene = sceneName;
        StartCoroutine(SceneLoadFade());
    }
}