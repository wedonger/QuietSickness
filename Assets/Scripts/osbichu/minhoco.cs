using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minhoco : MonoBehaviour
{
    public Collider areaAtivacao;
    public Transform areaAtivacaoTransform;
    public Transform player;
    public cactomove cactomove;
    public float speedCactor;
    public int velocidade = 2;
    public int[] rangeTempoDesgrudar = { 4, 8 };
    public bool grudado = false;
    private void Start()
    {
        speedCactor = cactomove.speed;
    }
    void Update()
    {
        if (areaAtivacao.bounds.Contains(player.position)) 
        {
            andar(player);
        }
        else if(!areaAtivacao.bounds.Contains(transform.position) && !grudado)
        {
            andar(areaAtivacaoTransform);
        }
    }
    public void atacar()
    {
        transform.SetParent(player);
        StartCoroutine(desgrudar());
        cactomove.speed = cactomove.speed / 3;
        grudado = true;
    }

    public void andar(Transform alvo) 
    {
        Vector3 direcao = (alvo.position - transform.position).normalized;
        Quaternion rotacaoZ = Quaternion.LookRotation(direcao, Vector3.up);

        transform.rotation = rotacaoZ * Quaternion.Euler(-90f, 0f, 0f);
        transform.position = Vector3.MoveTowards(transform.position, alvo.position, velocidade * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !grudado)
        {
            atacar();
        }
    }
    IEnumerator desgrudar()
    {
        int tempoGrudado = Random.Range(rangeTempoDesgrudar[0], rangeTempoDesgrudar[1]);
        yield return new WaitForSeconds(tempoGrudado);
        transform.SetParent(null);
        grudado = false;
        cactomove.speed = speedCactor;
    }
}
