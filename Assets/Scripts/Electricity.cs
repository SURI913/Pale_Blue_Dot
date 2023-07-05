using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electricity : TriggerObject
{
    public GameObject player;
    public GameObject objectA;
    public GameObject objectB;
    public GameObject thunder;
    //public LineRenderer lineA;
    //public LineRenderer lineB;
    public GameObject lineA;
    public GameObject lineB;

    State playerState;

    [SerializeField]
    private bool isPlayerConnected = false;

    private void Start()
    {
        lineA = Instantiate(thunder, transform.position, Quaternion.identity);
        lineB = Instantiate(thunder, transform.position, Quaternion.identity);
        //lineA = objectA.GetComponent<LineRenderer>();
        //lineB = objectB.GetComponent<LineRenderer>();
        //lineA.SetWidth(0.5f,0.5f);
        //lineB.SetWidth(0.5f,0.5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            playerState = player.GetComponent<PlayerController>().myState;
            if (playerState == State.Iron)
            {
                //lineA.enabled = true;
                //lineB.enabled = true;
                isPlayerConnected = true;
                isOn = true;
            }
            else if (playerState == State.Balloon)
            {
                // �÷��̾ �� ������ ���
                // ��ü A���� �÷��̾�� ���� ����
                isPlayerConnected = false;
                isOn = false;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            // �÷��̾ �浹�� ����� ���� ���� ����
            isPlayerConnected = false;
        }
        CallEvent();
    }

    private void Update()
    {
        lineA.SetActive(isOn);
        lineB.SetActive(isOn);

        if (isPlayerConnected)
        {
            //lineB.SetPositions(new Vector3[]{ player.transform.position, objectB.transform.position});
            //lineA.SetPositions(new Vector3[]{ objectA.transform.position, player.transform.position});
            // ���� ���� ���� ó��
            // �÷��̾�� ���⸦ �����ϴ� �ڵ� �ۼ�
            UpdateConnector(lineA, objectA.transform.position, player.transform.position);
            UpdateConnector(lineB, player.transform.position, objectB.transform.position);
        }
        //else if (isOn)
        //{
        //    //lineA.SetPositions(new Vector3[] { objectA.transform.position, objectB.transform.position });
        //    //lineB.SetPositions(new Vector3[] { objectB.transform.position, objectA.transform.position });
        //}
        else
        {
            //lineA.enabled = false;
            //lineB.enabled = false;
            UpdateConnector(lineA, objectA.transform.position, (objectA.transform.position + objectB.transform.position) / 2);
            UpdateConnector(lineB,objectB.transform.position, (objectA.transform.position + objectB.transform.position) / 2);
        }
    }

    private void UpdateConnector(GameObject thunder,Vector2 start,Vector2 end)
    {
        // ������Ʈ A�� ������Ʈ B�� ��ġ ���� ���
        Vector2 direction = end - start;

        // ���� ������Ʈ�� ��ġ ����
        thunder.transform.position = (start + end) / 2f;

        // ���� ������Ʈ�� ���� ����
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg+90f;
        thunder.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // ���� ������Ʈ�� ���� ����
        float distance = direction.magnitude;
        thunder.transform.localScale = new Vector3(2f, distance, 1f);
    }
}