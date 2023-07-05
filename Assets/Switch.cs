using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : TriggerObject
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("switch pushed");
        isOn = !isOn;
        CallEvent();
    }
}
