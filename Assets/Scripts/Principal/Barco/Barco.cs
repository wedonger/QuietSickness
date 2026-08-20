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
    public Transform motor;
    public Rigidbody rb;
    public Transform player;
    public Transform lindoia;
    public Transform saida;
    public Transform barco;
    public float trapaio = 0f;

    public float acceleration = 155f;
    public int steering = 2;    
    public float maxSpeed = 60f;

    public Barco(Barco obj)
    {
        motor = obj.motor;
        rb = obj.rb;
        player = obj.player;
        lindoia = obj.lindoia;
        saida = obj.saida;
        barco = obj.barco;
    }
    public Barco()
    {
        barco = this.barco;
        motor = this.motor;
        rb = this.rb;
        player = this.player;
        lindoia = this.lindoia;
        saida = this.saida;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float mov = Input.GetAxis("Vertical") * -1;   
        float turn = Input.GetAxis("Horizontal");

        Vector3 force = barco.transform.forward * mov * acceleration;

            rb.AddForce(force, ForceMode.Acceleration);

        float steerAmount = turn * Time.fixedDeltaTime;

        if (mov != 0)
            rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, steerAmount * steering, 0f));
    }
    public void salvaBarco()
    {
        saveSystem.salvaPosBarco(this);
    }
    public void loadTempo()
    {
        var obj = saveSystem.loadPosBarco();
        
    }
}
