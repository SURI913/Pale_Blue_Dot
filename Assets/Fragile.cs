using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fragile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        
        if (collision.gameObject.GetComponent<PlayerController>().myState == State.Iron&& collision.relativeVelocity.magnitude>10)
        {
            Debug.Log("break");
            Destroy(gameObject);
        }
    }
}
