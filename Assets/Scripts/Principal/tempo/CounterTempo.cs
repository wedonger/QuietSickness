using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterTempo : MonoBehaviour
{
    public Transform exo;
    public Transform escudo;
    private float duracaoDia = 600f;

    public bool jaTocoCutsceneMeteoro;
    private float deltaTempoPraBonito;
    public float tempo;
    public float deltaTempo;
    public int min, hora, dia;

    void Update()
    {
        float grausPorSegundo = 360f / duracaoDia;
        deltaTempoPraBonito += Time.deltaTime * tempo;
        deltaTempo += Time.deltaTime * tempo;

        if (deltaTempoPraBonito > 1)
        {
            min++;
            deltaTempoPraBonito = 0;
        }
        if (min >= 60)
        {
            hora++;
            min = 0;
        }
        if (hora >= 10)
        {
            dia++;
            hora = 0;
        }
        if (dia >= 4)
        {
            Debug.Log("cabo");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            salvarTempo();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            loadTempo();
        }

        float rotacao = grausPorSegundo * tempo;
        Debug.Log(@$"dia: {dia} | {hora}:{min}");
        escudo.transform.RotateAround(exo.position, transform.forward, rotacao * Time.deltaTime);
    }
    public void salvarTempo()
    {
        saveSystem.salvaDias(this);
    }
    public void loadTempo()
    {
        var obj = saveSystem.loadDias();
        hora = obj.hora;
        min = obj.min;
        dia = obj.dia;
        deltaTempo = obj.deltaTempo;
        jaTocoCutsceneMeteoro = obj.jaTocoCutsceneMeteoro;
    }
}