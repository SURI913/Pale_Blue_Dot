using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : EventObject
{
    [SerializeField]
    Animator anim;
    [SerializeField]
    BoxCollider2D collider;
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
        //Destroy(gameObject);
        anim.SetBool("isOn", true);
        collider.enabled = false;
    }
}
