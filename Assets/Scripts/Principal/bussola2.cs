using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class bussola2 : MonoBehaviour
{
    public Transform barco;
    void Update()
    {
        transform.LookAt(barco);
    }
}
