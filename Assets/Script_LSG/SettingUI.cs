using Michsky.UI.ModernUIPack;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    [SerializeField]
    private WindowManager SettingWindow;   //창

    private bool WindowOpen;

    //페이드 아웃용
    [SerializeField]
    private Image fadeEffect;

    private void Start() {
            Time.timeScale = 1; //시작
            SettingWindow.gameObject.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && WindowOpen == false)
        {
            SettingWindow.gameObject.SetActive(true);
            WindowOpen = true;
            Time.timeScale = 0; //일시정지

        }
        else if(Input.GetKeyDown(KeyCode.Escape)  && WindowOpen == true){
            SettingWindow.gameObject.SetActive(false);
            WindowOpen = false;
            Time.timeScale = 1; //시작
        }
    }

    public void LoadLobbyScenes()
    {
        SceneManager.LoadScene("StageScene");
    }

   public void FadeOut()
    {
        StartCoroutine("fadeOutStart");
    }

    IEnumerator fadeOutStart()
    {
        float fadeCount = 0; //처음 알파값
        while(fadeCount <= 1.0f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSecondsRealtime(0.01f);
            fadeEffect.color = new Color(0, 0, 0, fadeCount);
        }
    }

    /// <summary>
    /// 게임종료. 전처리기를 이용해 에디터 아닐때 종료.
    /// </summary>
    public void GameExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void LoadStageScenes()
    {
        SceneManager.LoadScene("Tuto");
    }
}

