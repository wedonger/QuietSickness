using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class longlulaMain : MonoBehaviour
{
    public Light nao_e_assim_que_funciona;
    private float argen;
    public float buenos = 0.3f; 

    void Update()
    {
        nao_e_assim_que_funciona.range = ovoLatejandoPulsando(nao_e_assim_que_funciona.range);
    }

    public float ovoLatejandoPulsando(float ranger)
    {
        if (ranger >= 100)
        {
            argen = -buenos;
        }
        else if (ranger <= 0)
        {
            argen = buenos;
        }
        return ranger + argen;
    }
}
