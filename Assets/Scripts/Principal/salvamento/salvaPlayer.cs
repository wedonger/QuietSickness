using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class salvaPlayer : MonoBehaviour
{
    public float x, y ,z;
    public salvaPlayer() 
    {
        x = 0;
        y = 0;
        z = 0;
    }
    public salvaPlayer(cactomove player)
    {
        if (player is null)
        {
            return;
        }
        x = player.transform.position.x;
        y = player.transform.position.y;
        z = player.transform.position.z;
    }
}
