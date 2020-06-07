using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag=="Boundary")
        {
            return;
        }
        Destroy(collider.gameObject);
        Destroy(gameObject);
    }
}
