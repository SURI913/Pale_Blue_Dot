using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UltimateRadialMenuExample.CharacterInventory2D.CharacterInventoryGameManager;

public class GameManager : MonoBehaviour
{
    
    void Awake()
    {
        
        SceneManager.LoadScene("SettingUI", LoadSceneMode.Additive);
    }

    public void setNomalState()
    {

    }

    

    /// <summary>
    /// This function is called by the WorldItem that has been picked up.
    /// </summary>
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
