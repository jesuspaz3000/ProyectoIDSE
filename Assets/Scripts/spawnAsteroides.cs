using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroides : MonoBehaviour
{
    public GameObject asteroidePrefab; // Referencia al prefab del asteroide
    public float spawnRate = 2.0f; // Tasa de aparición de asteroides por segundo

    private float nextSpawnTime;

    void Start()
    {
        nextSpawnTime = Time.time + spawnRate;
    }

    void Update()
    {
        // Generar un nuevo asteroide en intervalos regulares
        if (Time.time > nextSpawnTime)
        {
            SpawnAsteroide();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnAsteroide()
    {
        // Generar una posición aleatoria para el asteroide
        float randomX = Random.Range(-30.0f, 30.0f);
        Vector3 spawnPosition = new Vector3(randomX, 1.5f, 18.0f);

        // Instanciar el asteroide
        GameObject asteroide = Instantiate(asteroidePrefab, spawnPosition, Quaternion.identity);

        // Aquí puedes agregar código para mover el asteroide hacia -Z, por ejemplo, añadiendo un componente Rigidbody y aplicando una fuerza
        // asteroide.GetComponent<Rigidbody>().AddForce(Vector3.back * fuerza);
    }
}
