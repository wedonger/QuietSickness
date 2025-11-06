using LowPolyWater;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterMagneto : MonoBehaviour, IInteractable
{
    public static EnterMagneto instance;
    public GameObject PlayerBackup;
    public bool inVehicle = false;
    ControlaMagneto vehicleScript;
    cactomove cactomover;
    camera camer;
    AudioSource source;
    public GameObject player;
    public Transform saida;
    public AudioClip audio;
    Rigidbody rb;
    public Transform monitas;
    void Start()
    {
        GameObject barco = GameObject.Find("guidaocolider");
        barco.GetComponent<Barco>();
        vehicleScript = barco.GetComponent<ControlaMagneto>();
        vehicleScript.enabled = false;
        source = GetComponent<AudioSource>();
        GameObject nego = GameObject.Find("Player");
        cactomover = nego.GetComponent<cactomove>();
        GameObject cabeca = GameObject.Find("cabeç");
        camer = cabeca.GetComponent<camera>();
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
        if (inVehicle)
        {
            player.transform.position = saida.position;
            player.transform.rotation = saida.rotation;
        }
        if (Input.GetKeyDown(KeyCode.E) && inVehicle) 
        {
            PlayerBackup.SetActive(false);
            vehicleScript.enabled = false;
            cactomover.enabled = true;
            camer.enabled = true;
            inVehicle = false;
            rb.mass = 1;
            player.transform.SetParent(null);
            rb.useGravity = true;
            //source.PlayOneShot(GetComponent<AudioSource>(), 1);
            //guiObj.SetActive(false);
        }
    }
    public void Interact()
    {
        if (!inVehicle)
        {
            PlayerBackup.SetActive(true);
            vehicleScript.enabled = true;
            cactomover.enabled = false;
            camer.enabled = false;
            inVehicle = true;
            rb.mass = 0;
            rb.useGravity = false;
            player.transform.SetParent(saida, true);
            player.transform.position = saida.position;
            GameObject cabeca = GameObject.Find("cabeç");
            Vector3 alvo = monitas.position;
            alvo.y -= 0.3f;
            cabeca.transform.LookAt(alvo);
        }
    }
}
