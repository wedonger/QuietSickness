using LowPolyWater;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BarcoFisica : MonoBehaviour
{
    public Rigidbody rg;
    public float profundidadeAntes = 1f;
    public float displacementAmout = 3f;
    public int QuantidadeFloater = 2;
    public float DragAgua = 12f;
    public float AngularDragAgua = 10f;
    void FixedUpdate()
    {
        rg.AddForceAtPosition(Physics.gravity, transform.position, ForceMode.Acceleration);
        float altura = Lindoia.instance.GetWaveHeight(transform.position.x); 
        float displacementMultiplayer = altura - transform.position.y / profundidadeAntes;
        if (displacementMultiplayer > 0) {
            rg.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplayer, 0f), transform.position, ForceMode.Acceleration);
            rg.AddForce(displacementMultiplayer * -rg.velocity * DragAgua * Time.fixedDeltaTime, ForceMode.VelocityChange);
            rg.AddForce(displacementMultiplayer * -rg.angularVelocity * AngularDragAgua * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
    }
}
