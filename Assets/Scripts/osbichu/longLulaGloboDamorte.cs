using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class longLulaGloboDamorte : MonoBehaviour
{
    public bool dentro = false;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dentro = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        dentro = false;
    }
}
