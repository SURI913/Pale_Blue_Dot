using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventObject : MonoBehaviour
{
    [SerializeField]
    protected bool isOn;
    protected float angle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// �̺�Ʈ ������Ʈ�� ��� ����
    /// </summary>
    public virtual void Function(bool isOn)
    {
        Debug.Log(gameObject.name + isOn.ToString()) ;
        this.isOn = isOn;
    }
}
