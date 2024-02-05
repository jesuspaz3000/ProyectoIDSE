using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiverDesactiverSpawnerTrigger : MonoBehaviour
{
    public PrefabsSpawner [] SpawnersToActivate;
    public PrefabsSpawner [] SpawnersToDeactivate;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            foreach(PrefabsSpawner spawner in SpawnersToActivate){
                spawner.StartSpawnWaves();
            }

            foreach(PrefabsSpawner spawner in SpawnersToDeactivate){
                spawner.StopSpawn();
            }
        }
    }
}
