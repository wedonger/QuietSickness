using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class longlula : MonoBehaviour
{
    public Light yagami;
    public GameObject globoDaMorte;
    public GameObject player;

    void Update()
    {
        Vector3 direction = player.transform.position - yagami.transform.position;

        if (globoDaMorte.GetComponent<longLulaGloboDamorte>().dentro)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            yagami.transform.rotation = Quaternion.Slerp(yagami.transform.rotation, targetRotation, Time.deltaTime * 3);
            if (yagami.range < 700)
            {
                yagami.range += 10f;
            }
        }
        else
        {
            if(yagami.range <= 0)
            {
                Quaternion vidrorr = Quaternion.LookRotation(globoDaMorte.transform.position);
                yagami.transform.rotation = Quaternion.Slerp(yagami.transform.rotation, vidrorr, Time.deltaTime * 3);
            }
            else {
                yagami.range -= 0.5f;
            }
        }
    }
}
