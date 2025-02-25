using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacaConfig : MonoBehaviour
{
    public Outline linhafora;
    public Cameramenu cameramenu;
    void Start()
    {
        linhafora.enabled = false;
    }
    void OnMouseOver()
    {
        linhafora.enabled = true;
        if (Input.GetKey(KeyCode.Mouse0))
        {
            cameramenu.placaConfig = true;
        }
    }
    void OnMouseExit()
    {
        linhafora.enabled = false;
    }
}
