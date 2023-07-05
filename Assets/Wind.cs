using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : EventObject
{
    [SerializeField]
    private float moveSpeed;
    State ballState;
    Rigidbody2D otherRigidBody;
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
        ballState = collision.GetComponent<PlayerController>().myState;
        otherRigidBody = collision.gameObject.GetComponent<Rigidbody2D>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!isOn|| ballState != State.Balloon) return;

        // 현재 오브젝트의 회전값 가져오기
        float rotation = transform.rotation.eulerAngles.z;

        // 회전값을 라디안으로 변환
        float radianAngle = rotation * Mathf.Deg2Rad;

        // 라디안 각도로 이동 방향 구하기
        Vector2 moveDirection = new Vector2(Mathf.Cos(radianAngle), Mathf.Sin(radianAngle));

        // 이동시킬 대상 오브젝트 이동
        //collision.gameObject.transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        otherRigidBody.AddForce(moveDirection * moveSpeed * Time.deltaTime);
    }
}
