using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomInTrigerPrefabsSpawner : PrefabsSpawner
{
    public Collider SpawnPositionTriger;

    override protected Vector3 positionsSpawnGenerator(){
        return getRandomPositionInTrigger();
    }
    private Vector3 getRandomPositionInTrigger(){
        Vector3 triggerSize = SpawnPositionTriger.bounds.size;
        float randomX = Random.Range(-triggerSize.x/2f, triggerSize.x/2f);
        float randomY = Random.Range(-triggerSize.y/2f, triggerSize.y/2f);
        float randomZ = Random.Range(-triggerSize.z/2f, triggerSize.z/2f);

        return new Vector3(randomX, randomY, randomZ) + SpawnPositionTriger.transform.position;
    }
}
