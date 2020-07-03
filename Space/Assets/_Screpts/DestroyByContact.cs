using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;

    void Start()
    {
        GameObject gameControlerObject = GameObject.FindWithTag("GameController");
        if (gameControlerObject != null)
        {
            gameController = gameControlerObject.GetComponent<GameController>();
        }
        if (gameControlerObject == null)
        {
            Debug.Log("Can't find 'GameController' script");
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag=="Boundary")
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        if (collider.tag == "Player")
        {
            Instantiate(playerExplosion, collider.transform.position, collider.transform.rotation);
            gameController.GameOver();
        }
        if (collider.tag == "Ammo")
        {
            Destroy(collider.gameObject);
        }
        if (gameController.GameOVER)
        {
            Destroy(collider.gameObject);
        }
        gameController.AddScore(scoreValue);
        //Destroy(collider.gameObject);
        Destroy(gameObject);
    }
}
