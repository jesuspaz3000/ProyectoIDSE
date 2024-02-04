using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject[] Enemigos;
    public GameObject Camera;
    public int AsteroidesCount;
    public float spawnWait = 0.5f;
    public float startWait = 2.0f;
    public float oleadaWait = 4.0f;
    public bool stateWinner = false;

    private Coroutine spawnCoroutine;

    public void StartSwapn()
    {
        spawnCoroutine = StartCoroutine(SpawnAsteroides());
    }
    public void StopSwapn(){
        StopCoroutine(spawnCoroutine);
    }

    IEnumerator SpawnAsteroides()
    {
        yield return new WaitForSeconds(startWait);
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
}
