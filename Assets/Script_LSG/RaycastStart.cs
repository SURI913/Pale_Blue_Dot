using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastStart : MonoBehaviour
{
    private GameObject Maue;
    // Start is called before the first frame update
    void Start()
    {
        Maue = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if( Maue != null ) {
            if (Maue.activeSelf == true ) {
                this.GetComponent<Image>().raycastTarget = true;
            }
        }


    }
}
