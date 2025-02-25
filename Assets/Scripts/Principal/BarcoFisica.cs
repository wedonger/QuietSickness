using LowPolyWater;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarcoFisica : MonoBehaviour
{
    public Rigidbody rg;
    public float profundidadeAntes = 1f;
    public float displacementAmout = 3f;
    public int QuantidadeFloater = 2;
    public float DragAgua = 12f;
    public float AngularDragAgua = 10f;
    void Update()
    {
        rg.AddForceAtPosition(Physics.gravity / QuantidadeFloater, transform.position, ForceMode.Acceleration);

        float altura = Lindoia.instance.GetWaveHeight(transform.position.x);
        if (transform.position.y < altura)
        {
            float displacementMultiplayer = Mathf.Clamp01((altura -transform.position.y) / profundidadeAntes) * displacementAmout;
            rg.AddForce(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplayer, 0f), ForceMode.Acceleration);
            rg.AddForce(displacementMultiplayer * -rg.velocity * DragAgua * Time.fixedDeltaTime, ForceMode.VelocityChange); // ajeita o delta time
            rg.AddTorque(displacementMultiplayer * -rg.angularVelocity * AngularDragAgua * Time.fixedDeltaTime, ForceMode.VelocityChange);

        }
    }

}
