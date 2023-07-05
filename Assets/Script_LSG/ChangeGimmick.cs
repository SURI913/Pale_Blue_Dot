using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGimmick : MonoBehaviour
{
    public UltimateRadialMenu radialMenu;

    private void Start() {
        //Here we are subscribing to the Enabled and Disabled events so that we can pause and resume the game when the menu changes state.
		radialMenu.OnRadialMenuEnabled += PauseGame;
		radialMenu.OnRadialMenuDisabled += ResumeGame;
    }

    // This function is subscribed to the OnRadialMenuEnabled event.
		void PauseGame ()
		{
			Time.timeScale = 0.0f;
		}

		// This function is subscribed to the OnRadialMenuDisabled event.
		void ResumeGame ()
		{
			Time.timeScale = 1.0f;
		}
    
}
