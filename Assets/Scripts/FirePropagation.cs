using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePropagation : EventObject
{
    public bool isOnFire = false;  // 불이 붙었는지 여부
    public bool canSpreadFire = true;  // 불이 옮겨붙을 수 있는지 여부
    public bool breakable;
    public GameObject fire;
    public BoxCollider2D collider;
    GameObject fireObject;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!isOnFire) return;
        // 다른 불이 붙을 수 있는 오브젝트인지 확인
        FirePropagation otherFire = collision.gameObject.GetComponent<FirePropagation>();
        
        if (otherFire != null && otherFire.canSpreadFire)
        {
            if (collision.tag == "Player")
            {
                if (collision.gameObject.GetComponent<PlayerController>().myState == State.Wood)
                {
                    otherFire.Ignite();
                    return;
                }
                else return;
            }
            else if (collision.tag == "Water")
            {
                extinguish();
            }
            // 불이 붙지 않은 오브젝트에 불을 옮겨붙임
            otherFire.Ignite();
        }
    }

    void Ignite()
    {
        // 불이 이미 붙은 상태이거나 불이 옮겨붙을 수 없는 상태라면 리턴
        if (isOnFire || !canSpreadFire)
        {
            return;
        }

        // 불이 붙은 상태로 변경
        isOnFire = true;
        fireObject = Instantiate(fire,new Vector2(transform.position.x,transform.position.y+1),transform.rotation,this.transform);

        // 필요한 추가 동작 구현 (예: 불 파티클 재생, 오브젝트 제거 등)
        collider.isTrigger = true;
        Invoke("Fire", 3f);
    }
    
    public void extinguish()
    {
        Destroy(fireObject);
        isOnFire = false;
    }
    void Fire()
    {
        
        if (breakable)Destroy(gameObject);
    }
    public override void Function(bool isOn)
    {
        base.Function(isOn);
        Ignite();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
}
