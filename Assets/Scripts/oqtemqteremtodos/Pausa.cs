using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    public GameObject menu;
    public GameObject cabeca;
    public static bool zaWardo;
    void Start()
    {
        menu.SetActive(false);
        saveSystem.loadPosPlayer();
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
        cabeca.SetActive(false);
    }
    public void ParaTempo()
    {
        menu.SetActive(true);
        Time.timeScale = 0f;
        zaWardo = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        cabeca.SetActive(true);
    }

    public void voltaProMenu()
    {
        SceneManager.UnloadScene(1); //nnseiseprecisa falta chamar os metodos quando clica nos botao v i r o s
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
    public void SalvaGame() {
        var barco = FindObjectOfType<Barco>();
        var tempoObj = GameObject.Find("MadoInHeaven");
        var playerObj = GameObject.Find("Player");
        CounterTempo tmpo = tempoObj.gameObject.GetComponent<CounterTempo>();
        cactomove player = playerObj.gameObject.GetComponent<cactomove>();
        saveSystem.salvaDias(tmpo);
        saveSystem.salvaPosBarco(barco);
        saveSystem.salvaPosPlayer(player);

        galoClasse galo = new galoClasse();
        galo.salvarJojo();
    }
}
