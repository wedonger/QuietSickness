using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    public GameObject menu;
    public camera cabeca;
    public static bool zaWardo; 
    void Start()
    {
        menu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (zaWardo)
            {
                VoltaTempo();
            }
            else 
            {
                ParaTempo();
            }  
        }
    }

    public void VoltaTempo()
    {
        menu.SetActive(false);
        Time.timeScale = 1.0f;
        zaWardo = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        cabeca.enabled = true;
    }
    public void ParaTempo()
    {
        menu.SetActive(true);
        Time.timeScale = 0f;
        zaWardo = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        cabeca.enabled = false;
    }

    public void voltaProMenu()
    {
        SceneManager.UnloadScene(1); //nnseiseprecisa falta chamar os metodos quando clica nos botao v i r o s
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
