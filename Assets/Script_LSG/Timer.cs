using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float timeRemaining = 300f; // 5분 (300초) 타이머 설정
    private bool timerIsRunning = false;

    void Start()
    {
        StartTimer();
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                // 타이머 종료 처리
                timeRemaining = 0;
                timerIsRunning = false;
                TimerComplete();
            }
        }

        int minutes = Mathf.FloorToInt(timeRemaining / 60); // 분 계산
        int seconds = Mathf.FloorToInt(timeRemaining % 60); // 초 계산

        this.GetComponent<Text>().text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void StartTimer()
    {
        timerIsRunning = true;
    }

    private void TimerComplete()
    {
        // 타이머 완료 시 실행할 동작 처리
        Debug.Log("타이머 완료!");
    }
}