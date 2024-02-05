using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PrefabsSpawner : Spawner
{
    public GameObject[] PrefabsToSpawn;

    public int numWaves = -1;
    public int objectsForEachWave = 2;
    public float waitBetweenObjects = 0f;
    public float startWait = 2.0f;
    public float waitBetweenWaves = 4.0f;

    public bool playOnAwake = false;
    private Coroutine currentCoroutine;
    private bool inCoroutine = false;
    // public Func<Vector3> positionsSpawnGenerator;
    private int currentNVave = 0;

    void Start()
    {
        Initicalize();
        if (playOnAwake)
        {

            inCoroutine = true;
            StartSpawnWaves();
        }
    }
    virtual protected void Initicalize()
    {
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
        currentCoroutine = StartCoroutine(SpawnWavesInPositions(() => position));
    }

    public void StopSpawn()
    {
        currentNVave = 0;
        inCoroutine = false;
        // StopCoroutine(currentCoroutine);
    }
    IEnumerator SpawnWavesInPositions(Func<Vector3> newPosition)
    {
        print("1Spawn");
        yield return new WaitForSeconds(startWait);
        while (inCoroutine)
        {
            if (numWaves < 0 || currentNVave >= numWaves)
            {
                currentNVave++;
                StartCoroutine(SpawnOneWave(newPosition));
                // for (int i = 0; i < objectsForEachWave; i++)
                // {
                //     SpawnOnPosition(newPosition());
                //     yield return new WaitForSeconds(waitBetweenObjects);
                // }
                yield return new WaitForSeconds(waitBetweenWaves);
            }

        }
        currentNVave = 0;
    }
    public IEnumerator SpawnWaves()
    {
        print("2Spawn");

        yield return new WaitForSeconds(startWait);
        while (inCoroutine)
        {
            if (numWaves < 0 || currentNVave >= numWaves)
            {
                currentNVave++;
                StartCoroutine(SpawnOneWave(positionsSpawnGenerator));
                // for (int i = 0; i < objectsForEachWave; i++)
                // {
                //     (positionsSpawnOnPositionSpawnGenerator());
                //     yield return new WaitForSeconds(waitBetweenObjects);
                // }
                yield return new WaitForSeconds(waitBetweenWaves);
            }

        }
        currentNVave = 0;
    }
    public IEnumerator SpawnOneWave(Func<Vector3> newPosition)
    {
        for (int i = 0; i < objectsForEachWave; i++)
        {
            SpawnOnPosition(newPosition());
            yield return new WaitForSeconds(waitBetweenObjects);
        }
    }

    virtual protected Vector3 positionsSpawnGenerator()
    {
        return transform.position;
    }
}
