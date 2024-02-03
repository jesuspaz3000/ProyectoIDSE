using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    // explosion
    public GameObject explosionAsteroide;
    public GameObject explosionPlayer;

    public int scoreValue;
    private GameController gameController;

    void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (gameController.GetVida() == 1)
            {
                gameController.LowVida(-1);
                Instantiate(explosionAsteroide, transform.position, transform.rotation);
                Instantiate(explosionPlayer, transform.position, transform.rotation);
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
            else
            {
                Instantiate(explosionAsteroide, transform.position, transform.rotation);
                Destroy(gameObject);
                gameController.LowVida(-1);
            }
        }
        else if (other.CompareTag("Disparo"))
        {
            //Disminuir vida y destruirse
            gameController.AddScore(scoreValue);
            Instantiate(explosionAsteroide, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else
        {
            return;
        }
    }
}
