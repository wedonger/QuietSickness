using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ligo : MonoBehaviour
{
    public void interacao()
    {
        Light Raito = GetComponent<Light>();
        Raito.enabled = !Raito.enabled;
    }
}
