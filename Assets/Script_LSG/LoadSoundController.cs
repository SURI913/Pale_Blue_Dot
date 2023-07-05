using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSoundController : MonoBehaviour
{
    SoundManager soundcontroller;

    void Start(){
        soundcontroller = SoundManager.s_Instance;
    }

    public void OnPlayButtonClick(){
        soundcontroller.onPlayClickState();
    }
}
