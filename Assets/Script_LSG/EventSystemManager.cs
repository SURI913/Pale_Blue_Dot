using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventSystemManager : MonoBehaviour
{
    private static EventSystemManager instance;
    public EventSystem eventSystem;

    public static EventSystemManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<EventSystemManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("EventSystemManager");
                    instance = obj.AddComponent<EventSystemManager>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
