using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualogStroy : MonoBehaviour
{
    [SerializeField]
    private GameObject ShowDialog;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ShowDialog.SetActive(true);
    }
}
