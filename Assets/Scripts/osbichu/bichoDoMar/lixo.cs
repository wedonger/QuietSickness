using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lixo : MonoBehaviour
{
    public bichoDoMar merda;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            merda.achouPlayer(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            merda.achouPlayer(false);
        }
    }
}
