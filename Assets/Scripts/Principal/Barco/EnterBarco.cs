using LowPolyWater;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBarco : MonoBehaviour , IInteractable
{
    public static EnterBarco instance;
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
        GameObject barco = GameObject.Find("boiador");
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
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && inVehicle == false)
        {
            //guiObj.SetActive(true);
        }
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
        if (inVehicle) {
            player.transform.position = saida.position;
            player.transform.rotation = saida.rotation;
        }
    }
    public void Interact()
    {
        if (inVehicle)
        {
            PlayerBackup.SetActive(false);
            vehicleScript.enabled = false;
            cactomover.enabled = true;
            inVehicle = false;
            rb.mass = 1;
            player.transform.SetParent(null);
            rb.useGravity = true;
        }
        else
        {
            //source.PlayOneShot(GetComponent<AudioSource>(), 1);
            //guiObj.SetActive(false);
            PlayerBackup.SetActive(true);
            vehicleScript.enabled = true;
            cactomover.enabled = false;
            inVehicle = true;
            rb.mass = 0;
            rb.useGravity = false;
            player.transform.SetParent(saida, true);
            player.transform.position = saida.position;
        }
    }
}
