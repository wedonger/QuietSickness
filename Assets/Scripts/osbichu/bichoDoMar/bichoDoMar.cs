using System.Collections;
using System.Collections.Generic;
using LowPolyWater;
using Unity.VisualScripting;
using UnityEngine;

public class bichoDoMar : MonoBehaviour
{
    public Collider areaAtivacao;
    public Collider areaPatroling;
    public Transform areaAtivacaoTransform;
    public Transform player;
    public int velocidade = 0;
    private int velocidadeFix = 0;
    public Transform obichao;
    public Rigidbody rbBichao;
    private bool submergedo = true;
    private bool atacando = false;
    private bool sendoBoot = false;
    public bool achoPlayer = false;
    public bool podeAtacar = true;

    private void Start()
    {
        velocidadeFix = velocidade;
    }
    private void Update()
    {
        verificaSubmerged();
        andar();
        if (!submergedo && !atacando) 
        { 
            descerPraAgua();
        }
        if (!achoPlayer && submergedo && !atacando)
        {
            patroling();
        }
    }
    public void achouPlayer(bool acho) { //isso da trigger quando o mlk acha o player
        achoPlayer = acho;
        if (!achoPlayer) {
            return;
        }
        Vector3 diferenca = player.position - obichao.position;
        float distancia = diferenca.magnitude;
        Debug.Log(distancia);
        if (distancia >= 35) {
            Vector3 direcaoAteAlvo = player.position - transform.position;
            direcaoAteAlvo.y = transform.rotation.y;
            float angulo = Vector3.Angle(transform.forward, direcaoAteAlvo);
            if (angulo > 13f)
            {
                olharParaPlayer();
            }
            atacando = false;
        }
        else if (podeAtacar)
        {
            atacar();
        }
    }
    public void olharParaPlayer() 
    {
        Vector3 direcao = player.position - transform.position;
        direcao.y = transform.rotation.y;
        Quaternion rotacaoY = Quaternion.LookRotation(direcao);
        obichao.rotation = Quaternion.Slerp(obichao.rotation, rotacaoY, 3 * Time.deltaTime);
    }
    public void atacar()
    {
        Vector3 direcao = player.position - transform.position;
        Quaternion rotacao = Quaternion.LookRotation(direcao);
        obichao.rotation = Quaternion.Slerp(obichao.rotation, rotacao, 3 * Time.deltaTime);
        velocidade = 2 * velocidadeFix;
        atacando = true;
        StartCoroutine(TimeoutAtaque(5));
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
    }
    public void descerPraAgua()
    {
        Quaternion olharPara = Quaternion.Euler(40f, obichao.rotation.eulerAngles.y, obichao.rotation.eulerAngles.z);
        obichao.rotation = Quaternion.Slerp(obichao.rotation, olharPara, 3 * Time.deltaTime);
    }
    public void patroling()
    {
        Quaternion olharPara = Quaternion.Euler(obichao.rotation.eulerAngles.x, obichao.rotation.eulerAngles.y, obichao.rotation.eulerAngles.z);
        if (areaPatroling.bounds.Contains(obichao.position) && !sendoBoot)
        {
            sendoBoot = true;
            int segundosParaTrocarPos = Random.Range(3, 8);
            int angulor = Random.Range(-180, 180);
            angulor = ((angulor % 360) + 360) % 360; //normaliza os boom
            float diffY = obichao.rotation.y + angulor;
            olharPara = Quaternion.Euler(obichao.rotation.eulerAngles.x, diffY, obichao.rotation.eulerAngles.z);
            StartCoroutine(TimeoutBoot(segundosParaTrocarPos));
        }
        else if (!areaPatroling.bounds.Contains(obichao.position))
        {
            Vector3 direcao = areaPatroling.transform.position - transform.position;
            olharPara = Quaternion.LookRotation(direcao);
        }
        obichao.rotation = Quaternion.Slerp(obichao.rotation, olharPara, 3 * Time.deltaTime);
    }
    IEnumerator TimeoutBoot(float segundos)
    {
        yield return new WaitForSeconds(segundos);
        sendoBoot = false;
    }
    IEnumerator TimeoutAtaque(float segundos)
    {
        yield return new WaitForSeconds(segundos);
        atacando = false;
        podeAtacar = false;
        StartCoroutine(TimeoutPodeAtaca(30));
    }
    IEnumerator TimeoutPodeAtaca(float segundos)
    {
        yield return new WaitForSeconds(segundos);
        podeAtacar = true;
    }
}
