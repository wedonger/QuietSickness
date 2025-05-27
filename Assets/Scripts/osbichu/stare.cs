using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stare : MonoBehaviour
{
    public GameObject player;
    public camera classeCamera;
    
    void Update()
    {
        if(classeCamera.hit.transform == this.transform)
        {
            vaiPraOutroLugar();
        }
        transform.LookAt(player.transform.position); //medo.
    }

    public void vaiPraOutroLugar()
    {
        GameObject[] lugares = GameObject.FindGameObjectsWithTag("LugaresStare"); //lembra desse nome please
        
        if (lugares != null && lugares.Length != 0) {
            int aleatorio = Random.Range(lugares.Length - 1, 0);
            this.transform.position = lugares[aleatorio].transform.position;
        }
    }
}
