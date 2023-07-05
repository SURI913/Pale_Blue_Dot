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

        // ���� ������Ʈ�� ȸ���� ��������
        float rotation = transform.rotation.eulerAngles.z;

        // ȸ������ �������� ��ȯ
        float radianAngle = rotation * Mathf.Deg2Rad;

        // ���� ������ �̵� ���� ���ϱ�
        Vector2 moveDirection = new Vector2(Mathf.Cos(radianAngle), Mathf.Sin(radianAngle));

        // �̵���ų ��� ������Ʈ �̵�
        //collision.gameObject.transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        otherRigidBody.AddForce(moveDirection * moveSpeed * Time.deltaTime);
    }
}
