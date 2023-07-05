using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Count : MonoBehaviour
{
    private int count = 0;
    [SerializeField]
     private TextMeshProUGUI countText;
    
    private void Start() {
        countText = GetComponent<TextMeshProUGUI>();
    }
    public void setCount (int count){
        this.count = count;
    }

    public void drawCount(){
        switch (count)
        {
            case 0: {Debug.Log("Count 없음"); break;} //countText.text = "ZERO";
            case 1: {countText.text = "ONE"; break;}
            case 2: {countText.text = "TWO"; break;}
            case 3: {countText.text = "THREE"; break;}
            case 4: {countText.text = "FOUR"; break;}
            case 5: {countText.text = "FIVE"; Debug.Log("목숨 소진"); break;}
            default: {Debug.Log("Count 오류!"); break;}
        }
    }
}
