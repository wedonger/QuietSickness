using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metoeor : MonoBehaviour
{
    public Animator animator;
    public Collider areaAtivacao;
    public Transform player;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (areaAtivacao.bounds.Contains(player.position))
            animator.SetBool("entroNaAreaBoom", true);
        }
    }
}
