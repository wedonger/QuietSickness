using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Vector2 turn;
    public float sensitivity = .5f;
    public Vector3 deltaMove;
    public float speed = 1;
    public float uplimit = 70;
    public float downlimit = 50;   
    public RaycastHit hit;
    public float dessaNoz = 5.0f;

    void Update()
    {
        Ray raio = new Ray(this.transform.position, this.transform.forward);
        Physics.Raycast(raio, out hit, dessaNoz);
        Debug.DrawLine(this.transform.position, this.transform.forward, Color.red);
        turn.y += Input.GetAxis("Mouse Y") * sensitivity;

        if (turn.y >= uplimit)
        {
            turn.y = uplimit;
        }
        else if (turn.y <= -downlimit)
        {
            turn.y = -downlimit;
        }

        transform.localRotation = Quaternion.Euler(-turn.y, 0, 0);
    }
}