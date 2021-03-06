﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float tilt;
    public Boundary boundary;
    
    public GameObject bolt;
    public GameObject shotSpawn;
    public float fireRate;

    private float nextFire = 0.0f;

    void Update()
    {
        if (Input.GetButton("Fire1")&&Time.time>nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bolt, shotSpawn.transform.position, shotSpawn.transform.rotation);
            GetComponent<AudioSource>().Play();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    void FixedUpdate()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f);
        rb.velocity = movement * speed;

        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax),
            0f);
        rb.rotation = Quaternion.Euler((180 + rb.velocity.y) * tilt, 0f, 90f);
    }
}
