using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using LowPolyWater;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Barco : MonoBehaviour
{
    private float speed = 40f;
    public Transform motor;
    public Rigidbody rb;
    public Transform player;
    public Transform lindoia;
    public Transform saida;
    public Transform barco;
    public float trapaio = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float movy = Input.GetAxisRaw("Vertical");
        float movx = Input.GetAxisRaw("Horizontal");
        if (speed <= 40)
        {
            speed += movy;
        }
        if (speed > 0)// famosa lei da fisica
        { 
            speed -= 0.3f;
        }
        else if (speed < 0)
        {
            speed += 0.3f;
        }
        Vector3 deltaMove = motor.transform.forward * speed;
        float altura = Lindoia.instance.GetWaveHeight(transform.position.x);
        if (motor.position.y <= altura)
        {
            rb.AddForceAtPosition(deltaMove, transform.position, ForceMode.Acceleration);
            if (movx != 0 && speed > 1)
            {
                trapaio = transform.eulerAngles.y + movx / 2;
                transform.localRotation = Quaternion.Euler(0, trapaio, 0);
            }
        }
    }
    public void salvarTempo()
    {
        saveSystem.salvaPosBarco(this);
    }
    public void loadTempo()
    {
        var obj = saveSystem.loadPosBarco();
        
    }
}
