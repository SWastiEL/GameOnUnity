using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    //public GameObject playerExplosion;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag=="Boundary")
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        //if (collider.tag=="Player")
        //{
        //    Instantiate(playerExplosion, collider.transform.position, collider.transform.rotation);
        //}
        Destroy(collider.gameObject);
        Destroy(gameObject);
    }
}
