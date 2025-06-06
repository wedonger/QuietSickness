using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metoeor : MonoBehaviour
{
    public Animator animator;
    public Collider areaAtivacao;
    public Transform player;
    public GameObject meteororor;

    private void Start()
    {
        animator = meteororor.GetComponent<Animator>();
    }
    void Update()
    {
        if (areaAtivacao.bounds.Contains(player.position)) {
            Debug.Log("fez");
            animator.SetBool("entroNaAreaBoom", true);
        }
    }
}
