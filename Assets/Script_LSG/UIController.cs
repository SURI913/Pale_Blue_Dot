using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private void PauseGameInput()
    {
        Time.timeScale = 1.0f;
    }

    private void PlayGameInput()
    {
        Time.timeScale = 0.0f;

    }
    void Update()
    {
        //���콺�� ����
        if(Input.GetMouseButtonDown(1)){
            PlayGameInput();
        }
        else if (Input.GetMouseButtonUp(1))
        {
            PauseGameInput();
        }
    }
}
