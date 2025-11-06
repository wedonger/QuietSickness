using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlacaQuiet : MonoBehaviour
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
            cameramenu.placaEntrarQuiet = true;
        }
    }
    void OnMouseExit()
    {
        linhafora.enabled = false;
    }
}
