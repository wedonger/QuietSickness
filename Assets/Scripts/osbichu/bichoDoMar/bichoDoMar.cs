using System.Collections;
using System.Collections.Generic;
using LowPolyWater;
using Unity.VisualScripting;
using UnityEngine;

public class bichoDoMar : MonoBehaviour
{
    public Collider areaAtivacao;
    public Transform areaAtivacaoTransform;
    public Transform player;
    public int velocidade = 2;
    public Transform obichao;
    public Rigidbody rbBichao;
    private bool submergedo = true;
    private bool atacando = false;

    private void Update()
    {
        verificaSubmerged();
        andar();
        if (!submergedo && !atacando) { 
            descerPraAgua();
        }
    }
    public void achouPlayer() { //isso da trigger quando o mlk acha o player
        float distancia = Vector3.Distance(obichao.position, player.position);
        if (distancia >= 30) {
            olharParaPlayer();
        }
        else if (!atacando) {
            atacar();
        }
    }
    public void olharParaPlayer() 
    {
        if (!submergedo) {
            descerPraAgua();
            return;
        }
        Vector3 playerPos = player.position;
        playerPos.y = obichao.position.y;
        Quaternion olharPara = Quaternion.Euler(0f, obichao.rotation.eulerAngles.y, obichao.rotation.eulerAngles.z);
        obichao.rotation = Quaternion.Slerp(obichao.rotation, olharPara, 3 * Time.deltaTime);
    }
    public void atacar()
    {
        Quaternion olharPara = Quaternion.Euler(40f, obichao.rotation.eulerAngles.y, obichao.rotation.eulerAngles.z);
        obichao.rotation = Quaternion.Slerp(obichao.rotation, olharPara, 3 * Time.deltaTime);
    }
    public void andar()
    {
        Vector3 destino = transform.position + transform.forward;
        transform.position = Vector3.MoveTowards(transform.position, destino, velocidade * Time.deltaTime);
    }
    public void verificaSubmerged() {
        float alturaOnda = Lindoia.instance.GetWaveHeight(obichao.position.x);
        float alturaOndaComDiff = alturaOnda - 10;
        if (obichao.position.y < alturaOndaComDiff)
        {
            submergedo = true;
        }
        else
        {
            submergedo = false;
        }
        Debug.Log(submergedo);
    }
    public void descerPraAgua()
    {
        Quaternion olharPara = Quaternion.Euler(40f, obichao.rotation.eulerAngles.y, obichao.rotation.eulerAngles.z);
        obichao.rotation = Quaternion.Slerp(obichao.rotation, olharPara, 3 * Time.deltaTime);
    }
}
