using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Metoeor : MonoBehaviour
{
    public Animator animator;
    public Collider areaAtivacao;
    public Transform playerCamera;
    public GameObject meteororor;
    public CounterTempo countertempo;
    private bool jaAtivouEventoMeteoro = false;
    private galoClasse obj = new galoClasse();
    private string caminho = "";
    private camera camerar;
    private cactomove cactomove;
    public GameObject cabeca;
    public GameObject player;
    public bool animTerminou = false;

    private void Start()
    {
        animator = meteororor.GetComponent<Animator>();
        camerar = cabeca.GetComponent<camera>();
        cactomove = player.GetComponent<cactomove>();
        countertempo.enabled = false;
    }
    void Update()
    {
        caminho = Application.persistentDataPath + "/galoEventos.json";
        string jsonStringor = File.ReadAllText(caminho);
        if (!File.Exists(caminho) || String.IsNullOrEmpty(jsonStringor))
        {
            obj.eventoMeteoro = false;
            string json = JsonUtility.ToJson(obj);
            File.WriteAllText(caminho, json);
        }
        obj = JsonUtility.FromJson<galoClasse>(jsonStringor);
        countertempo.enabled = obj.eventoMeteoro;

        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
        if (info.IsName("meteorCaindo"))
        {
            playerCamera.LookAt(meteororor.transform.position);
        }

        if (areaAtivacao.bounds.Contains(playerCamera.position) && !obj.eventoMeteoro) 
        {
            animator.SetBool("entroNaAreaBoom", true);
            camerar.enabled = false;
            cactomove.enabled = false;
        }
    }
    public void ativaCutsceneMeteoro() {
        animator.SetBool("entroNaAreaBoom", false);
        countertempo.enabled = true;
        obj.eventoMeteoro = true;
        camerar.enabled = true;
        cactomove.enabled = true;
        string json = JsonUtility.ToJson(obj);
        File.WriteAllText(caminho, json);
    }
    public void AnimacaoTerminou()
    {
        animTerminou = true;
    }
}
