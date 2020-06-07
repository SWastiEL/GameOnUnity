using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RanomRotatator : MonoBehaviour
{
    public float tumble;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
