using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePropagation : EventObject
{
    public bool isOnFire = false;  // ���� �پ����� ����
    public bool canSpreadFire = true;  // ���� �Űܺ��� �� �ִ��� ����
    public bool breakable;
    public GameObject fire;
    public BoxCollider2D collider;
    GameObject fireObject;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!isOnFire) return;
        // �ٸ� ���� ���� �� �ִ� ������Ʈ���� Ȯ��
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
            // ���� ���� ���� ������Ʈ�� ���� �Űܺ���
            otherFire.Ignite();
        }
    }

    void Ignite()
    {
        // ���� �̹� ���� �����̰ų� ���� �Űܺ��� �� ���� ���¶�� ����
        if (isOnFire || !canSpreadFire)
        {
            return;
        }

        // ���� ���� ���·� ����
        isOnFire = true;
        fireObject = Instantiate(fire,new Vector2(transform.position.x,transform.position.y+1),transform.rotation,this.transform);

        // �ʿ��� �߰� ���� ���� (��: �� ��ƼŬ ���, ������Ʈ ���� ��)
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
