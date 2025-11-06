using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class salvaDias
{
    public int min, hora, dia;
    public float deltaTempo;
    public bool jaTocoCutsceneMeteoro;
    public salvaDias(CounterTempo counter) 
    { 
        min = counter.min;
        hora = counter.hora;
        dia = counter.dia;
        deltaTempo = counter.deltaTempo;
        jaTocoCutsceneMeteoro = counter.jaTocoCutsceneMeteoro;
    }
}
