using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObject : MonoBehaviour
{
    [SerializeField]
    protected bool isOn;
    [SerializeField,Tooltip("�̺�Ʈ�� �����ϰ����ϴ� ������Ʈ")]
    public EventObject[] eventObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// �̺�Ʈ ������Ʈ�� ��� ȣ��
    /// </summary>
    /// <param name="eventObject"></param>
    public void CallEvent()
    {
       // isOn = !isOn;
        foreach(EventObject eventObject1 in eventObject)
        {
            eventObject1.Function(isOn);
        }
    }
}
