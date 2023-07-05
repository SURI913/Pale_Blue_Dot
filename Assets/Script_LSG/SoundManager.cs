using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager s_Instance = null;

    void Awake()
    {
        if(s_Instance){
            DestroyImmediate(this.gameObject);
            return;
        }
        s_Instance = this;
        DontDestroyOnLoad(this.gameObject);

    }

    private AudioSource[] childAudioSources;
    /* 
    ID랑 통일
    Nomal = 0
    Iron = 1
    Rubber = 2
    Wood = 3
    장애물 사운드로 변경

    Button = 4
    Highlight = 5
    background = 6 음악 일시정지용
     */
    void Start()
    {
        childAudioSources = GetComponentsInChildren<AudioSource>();

        int numOfChild = this.transform.childCount;
        for (int i = 0; i < numOfChild; i++) {
            Debug.Log(transform.GetChild(i).name);
        }
    }
    
    //효과 재생
    public void onPlayJumpState(){
        childAudioSources[0].Play();
    }

    public void onPlayIronState(){
        childAudioSources[1].Play();
    }

    public void onPlayRubberState(){
        childAudioSources[2].Play();
    }

    public void onPlayWoodState(){
        childAudioSources[3].Play();
    }

    public void onPlayClickState(){
        childAudioSources[4].Play();
    }

    public void onPlayHighlightState(){
        childAudioSources[5].Play();
    }

    //배경음악 멈춤 및 재생
    public void onPauseBGM(){
        if (childAudioSources.Length > 0)
        {
            childAudioSources[childAudioSources.Length - 1].Pause();
        }
    }

    public void onPlayBGM(){
        if (childAudioSources.Length > 0)
        {
            childAudioSources[childAudioSources.Length - 1].Play();
        }
    }

    //볼륨조절 

    //효과음 및 배경음악 재생 함수
    public void SetSoundVloum(float volume){
        for (int i = 0; i < childAudioSources.Length-1; i++) {
           childAudioSources[i].volume = volume;
        }
    }

    public void SetMusicVloum(float volume){
        if (childAudioSources.Length > 0)
        {
            childAudioSources[childAudioSources.Length - 1].volume = volume;
        }
    }
    
}
