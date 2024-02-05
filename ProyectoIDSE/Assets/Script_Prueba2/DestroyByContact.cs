using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    // explosion
    public GameObject explosionAsteroide;
    public GameObject explosionPlayer;

    // Vida
    public int vida;

    // Puntuacion
    public int scoreValue;
    public int scoreDaño;
    private GameController gameController;
    private GameOverController gameOverController;//GAME OVER

    void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        gameOverController = GameObject.FindWithTag("GameController").GetComponent<GameOverController>();//GAME OVER
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
                gameOverController.GameOver();//GAME OVER
                gameController.SetStatusGame(false);
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
            if (vida>1)
            {
                vida -= 1;
                gameController.AddScore(scoreDaño);
                Instantiate(explosionAsteroide, transform.position, transform.rotation);
                Destroy(other.gameObject);
            }
            else
            {
                vida -= 1;
                gameController.AddScore(scoreValue);
                Instantiate(explosionAsteroide, transform.position, transform.rotation);
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
        else if (other.CompareTag("Asteroide"))
        {
            Instantiate(explosionAsteroide, transform.position, transform.rotation);
            if (gameObject.CompareTag("Enemigo"))
            {
                vida -= 1;
                Destroy(other.gameObject);
                return;
            }
            Destroy(gameObject);
        }
        else
        {
            return;
        }
    }
}
