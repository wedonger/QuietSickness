using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class salvaBarco
{
    public float[] pos = new float[3];
    public float[] rot = new float[3];

    public salvaBarco(Barco barco)
    {
        pos[0] = barco.transform.position.x;
        pos[1] = barco.transform.position.y;
        pos[2] = barco.transform.position.z;

        rot[0] = barco.transform.rotation.x;
        rot[1] = barco.transform.rotation.y;
        rot[2] = barco.transform.rotation.z;
    }
}
