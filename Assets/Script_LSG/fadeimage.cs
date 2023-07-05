using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class fadeimage : MonoBehaviour
{
    private Image fadeEffect;

    private void Awake()
    {
        fadeEffect = GetComponent<Image>();
        StartCoroutine("fadeOutStart");

    }

    IEnumerator fadeOutStart()
    {
        float fadeCount = 0; //처음 알파값
        while (fadeCount <= 1.0f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSecondsRealtime(0.01f);
            fadeEffect.color = new Color(255, 255, 255, fadeCount);
        }
        yield return new WaitForSecondsRealtime(1.0f);
        while (fadeCount >= 0.0f)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSecondsRealtime(0.01f);
            fadeEffect.color = new Color(255, 255, 255, fadeCount);
        }
        yield return new WaitForSecondsRealtime(0.3f);

        SceneManager.LoadScene("Tuto");

    }

}
