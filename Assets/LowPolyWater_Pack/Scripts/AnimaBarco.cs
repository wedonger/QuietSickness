using LowPolyWater;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimaBarco : MonoBehaviour
{
    public Transform motor;
    public Rigidbody rigidbori;

    void Update()
    {
        StartCoroutine(esperamano());
    }

    IEnumerator esperamano()
    {
        yield return new WaitForSeconds(1);
        rigidbori.AddForceAtPosition((Physics.gravity * Random.Range(0f, 2f) * Time.deltaTime) / 4, motor.position, ForceMode.Acceleration);
    }
}
