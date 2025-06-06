using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Barco : MonoBehaviour
{
    public float speed = 40f;
    public Transform motor;
    public Rigidbody rb;
    public Transform player;
    public Transform saida;
    public Transform barco;
    private float trapaio = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float movy = Input.GetAxisRaw("Vertical");
        float movx = Input.GetAxisRaw("Horizontal");
        Vector3 deltaMove = motor.transform.forward * movy * speed;
        rb.AddForceAtPosition(deltaMove, motor.position, ForceMode.Acceleration);
        if (movx != 0)
        {
            trapaio += movx;
            transform.localRotation = Quaternion.Euler(0, trapaio, 0);
        }
    }
}
