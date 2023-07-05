using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : EventObject
{
    GameObject fire;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Function(bool isOn)
    {
        base.Function(isOn);
        fire.SetActive(isOn);
    }
}
