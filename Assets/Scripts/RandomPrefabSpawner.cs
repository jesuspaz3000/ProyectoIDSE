using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PrefabsSpawner : Spawner
{
    public GameObject[] PrefabsToSpawn;

    public int objectsForEachWave;
    public float spawnWait = 0f;
    public float startWait = 2.0f;
    public float waitBetweenWaves = 4.0f;

    public bool playOnAwake = false;
    private Coroutine currentCoroutine;
    private bool inCoroutine = false;
    // public Func<Vector3> positionsSpawnGenerator;

    void Start(){
        Initicalize();
        if(playOnAwake){
            
            inCoroutine = true;
            StartSpawnWaves();
        }
    }
    virtual protected void Initicalize(){
        // positionsSpawnGenerator = () => transform.position;
    }
    override public GameObject Spawn()
    {
        return Instantiate(getRandomPrefab(), transform.position, Quaternion.identity);
    }
    public GameObject Spawn(int index)
    {
        return Instantiate(getPrefab(index), transform.position, Quaternion.identity);
    }
    override public GameObject SpawnOnPosition(Vector3 position)
    {
        return Instantiate(getRandomPrefab(), position, Quaternion.identity);
    }
    public GameObject SpawnOnPosition(Vector3 position, int index)
    {
        return Instantiate(getPrefab(index), position, Quaternion.identity);
    }
    public GameObject getRandomPrefab()
    {
        if (PrefabsToSpawn == null || PrefabsToSpawn.Length == 0)
        {
            return null;
        }
        int randomIndex = UnityEngine.Random.Range(0, PrefabsToSpawn.Length);
        return PrefabsToSpawn[randomIndex];
    }
    public GameObject getPrefab(int index)
    {
        return PrefabsToSpawn[index];
    }

    public void StartSpawnWaves()
    {
        inCoroutine = true;
        currentCoroutine = StartCoroutine(SpawnWavesInPositions(positionsSpawnGenerator));
    }
    public void StartSpawnWavesInPosition(Vector3 position)
    {
        inCoroutine = true;
        currentCoroutine = StartCoroutine(SpawnWavesInPositions(()=>position));
    }
    
    public void StopSpawn()
    {
        inCoroutine = false;
        // StopCoroutine(currentCoroutine);
    }
    IEnumerator SpawnWavesInPositions(Func<Vector3> newPosition)
    {
        print("1Spawn");
        yield return new WaitForSeconds(startWait);
        while (inCoroutine)
        {
            // objectsForEachWave = Random.Range(1, 20);
            for (int i = 0; i < objectsForEachWave; i++)
            {
                SpawnOnPosition(newPosition());
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waitBetweenWaves);
        }
    }
    IEnumerator SpawnWaves()
    {
        print("2Spawn");
        yield return new WaitForSeconds(startWait);
        while (inCoroutine)
        {
            // objectsForEachWave = Random.Range(1, 20);
            for (int i = 0; i < objectsForEachWave; i++)
            {
                SpawnOnPosition(positionsSpawnGenerator());
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waitBetweenWaves);
        }
    }

    virtual protected Vector3 positionsSpawnGenerator(){
        return transform.position;
    }

    
}
