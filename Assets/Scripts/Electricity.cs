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
                // 플레이어가 고무 상태인 경우
                // 물체 A에서 플레이어로 전기 연결
                isPlayerConnected = false;
                isOn = false;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            // 플레이어가 충돌을 벗어나면 전기 연결 해제
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
            // 전기 연결 상태 처리
            // 플레이어에게 전기를 전달하는 코드 작성
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
        // 오브젝트 A와 오브젝트 B의 위치 차이 계산
        Vector2 direction = end - start;

        // 연결 오브젝트의 위치 설정
        thunder.transform.position = (start + end) / 2f;

        // 연결 오브젝트의 각도 설정
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg+90f;
        thunder.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // 연결 오브젝트의 길이 설정
        float distance = direction.magnitude;
        thunder.transform.localScale = new Vector3(2f, distance, 1f);
    }
}