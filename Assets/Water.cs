using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField,Tooltip("600으로 테스트")]
    private float speed;
    Rigidbody2D otherRigidbody;
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
        if (collision.tag == "Player") otherRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player") otherRigidbody.AddForce(Vector2.up *Time.fixedDeltaTime*speed);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
