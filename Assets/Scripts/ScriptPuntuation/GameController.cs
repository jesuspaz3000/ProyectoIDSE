using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class GameController : MonoBehaviour
{
    public GameObject[] Enemigos;
    public GameObject Camera;
    public int AsteroidesCount;
    public float spawnWait = 0.5f;
    public float startWait = 2.0f;
    public float oleadaWait = 4.0f;
    public bool stateWinner = false;

    //Puntuacion
    private int score;
    public Text scoreText;

    //Vida
    private int vida;
    public Text vidaText;
    // Start is called before the first frame update
    void Start()
    {
        score = 100;
        vida = 5;
        UpdateCanvas();
        StartCoroutine(SpawnAsteroides());
    }

    // Update is called once per frame
    IEnumerator SpawnAsteroides()
    {
        yield return new WaitForSeconds(startWait);
        //AsteroidesCount = Random.Range(1, 10);
        while (true)
        {
            AsteroidesCount = Random.Range(1, 20);
            if (stateWinner == true) { 
                break; 
            }
            for (int i = 0; i < AsteroidesCount; i++)
            {
                Vector3 cameraPosition = Camera.transform.position;
                Vector3 spawnPosition = new Vector3(Random.Range(-40, 40), 1, cameraPosition.z + 25);
                GameObject enemigo = Enemigos[Random.Range(0,Enemigos.Length)];
                Instantiate(enemigo, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(oleadaWait);
        }
    }
    public void AddScore(int value)
    {
        score += value;
        UpdateCanvas();
    }
    
    void UpdateCanvas()
    {
        scoreText.text = "Puntos del Nivel: " + score;
        vidaText.text = "Vida: " + vida;
    }
    public int GetVida()
    {
        return vida;
    }
    public void LowVida(int value)
    {
        vida += value;
        //disminuir energia
        //disminuir puntaje
        score -= 20;
        UpdateCanvas();
    }
}
