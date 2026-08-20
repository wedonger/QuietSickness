using System.Globalization;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;

public class galoClasse : MonoBehaviour
{
    public salvaDias salvaDias { get; set; }
    public Barco Barco { get; set; }
    public salvaPlayer salvaPlayer { get; set; }
    public bool eventoMeteoro;
    public galoClasse() {
        salvaDias = new salvaDias();
        Barco = new Barco();
        salvaPlayer = new salvaPlayer();
        eventoMeteoro = false;
    }
    public void salvarJojo()
    {
        salvaPlayer = new salvaPlayer(buscaObjPlayer());
        Barco = new Barco(buscaObjBarco());
        salvaDias = new salvaDias(buscaObjDias());
        saveSystem.salvaJson(this);
    }
    public cactomove buscaObjPlayer()
    { 
        cactomove player = GameObject.FindGameObjectWithTag("Player").GetComponent<cactomove>();
        return player;
    }
    public Barco buscaObjBarco()
    { 
        Barco barco = GameObject.Find("boiador").GetComponent<Barco>();
        return barco;
    }
    public CounterTempo buscaObjDias()
    {
        CounterTempo barco = GameObject.Find("MadoInHeaven").GetComponent<CounterTempo>();
        return barco;
    }
}