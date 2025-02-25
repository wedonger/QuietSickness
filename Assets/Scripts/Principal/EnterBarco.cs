using LowPolyWater;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBarco : MonoBehaviour , IInteractable
{
    public static EnterBarco instance;
    public GameObject Vehicle;
    public GameObject PlayerBackup;
    public bool inVehicle = false;
    Barco vehicleScript;
    cactomove cactomover;
    GameObject guiObj;
    AudioSource source;
    public GameObject player;
    public Transform saida;
    public AudioClip audio;
    Rigidbody rb;
    void Start()
    {
        GameObject barco = GameObject.Find("Boiador");
        barco.GetComponent<Barco>();
        vehicleScript = barco.GetComponent<Barco>();
        vehicleScript.enabled = false;
        source = GetComponent<AudioSource>();
        GameObject nego = GameObject.Find("Player");
        nego.GetComponent<cactomove>();
        cactomover = nego.GetComponent<cactomove>();
        //guiObj = GameObject.Find("Press E");
        //guiObj.SetActive(false);
        PlayerBackup.SetActive(false);
        rb = nego.GetComponent<Rigidbody>();
    }

    public void Awake()
    {
        //Get the Mesh Filter of the gameobject
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        //if (other.gameObject.tag == "Player" && inVehicle == false)
        //{
        //    guiObj.SetActive(true);
        //}
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
           // guiObj.SetActive(false);
        }
    }
    void Update()
    {
        
    }
    public void Interact()
    {
        if (!inVehicle)
        {
            // source.PlayOneShot(GetComponent<AudioSource>(), 1);
            // guiObj.SetActive(false);
            PlayerBackup.SetActive(true);
            vehicleScript.enabled = true;
            cactomover.enabled = false;
            inVehicle = true;
            //rb.useGravity = true;
            player.transform.SetParent(saida);
            player.transform.position = saida.position;
            player.transform.rotation = saida.rotation;

        }
        else
        {
            PlayerBackup.SetActive(false);
            vehicleScript.enabled = false;
            cactomover.enabled = true;
            inVehicle = false;
            player.transform.SetParent(null);
            //rb.useGravity = false;
        }
    }
}
