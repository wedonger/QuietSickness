using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaMagneto : MonoBehaviour
{
    public Quaternion turn;
    public Transform camerar;
    float rotX, rotY;

    public Transform destino;
    public float distancia;

    private float t;
    private bool ativoCamera = false;
    private void Start()
    {
        camerar = GameObject.Find("camerar").transform; //isso pode dar uma merda
        destino = GameObject.Find("bracoVolta").transform;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ativoCamera = !ativoCamera;
        }
        if (ativoCamera)
        {
            cameraAtivada();
        }
        else
        {
            recolheCamera();
        }
    }
    void cameraAtivada()
    {
        rotX += Input.GetAxis("Mouse X");
        rotY -= Input.GetAxis("Mouse Y");
        rotY = Mathf.Clamp(rotY, 20f, 130f);

        camerar.rotation = Quaternion.Euler(rotY, rotX, 0f);

        Vector3 direcao = camerar.forward * 5;
        camerar.position += direcao * Time.deltaTime;
        distancia = Vector3.Distance(destino.position, camerar.position);
        if (distancia > 30)
        {
            recolheCamera();
        }
    }
    void recolheCamera()
    {
        var distancia = Vector3.Distance(camerar.position, destino.position);
        if (distancia > 2) {
            camerar.position = Vector3.MoveTowards(camerar.position, destino.position, 1f);
        }
        else {
            t = 5;
        }
        ativoCamera = false;
    }
}
