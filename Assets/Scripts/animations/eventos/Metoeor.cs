using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metoeor : MonoBehaviour
{
    public Animator animator;
    public Collider areaAtivacao;
    public Transform player;
    public GameObject meteororor;
    public CounterTempo countertempo;

    private void Start()
    {
        animator = meteororor.GetComponent<Animator>();
        countertempo.enabled = false;
    }
    void Update()
    {
        if (areaAtivacao.bounds.Contains(player.position)) {
            animator.SetBool("entroNaAreaBoom", true);
            countertempo.enabled = true;
        }
    }
}
