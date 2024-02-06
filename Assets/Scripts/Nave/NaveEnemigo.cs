using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PrefatProbability
{
    public GameObject prefabLetOnDeath;
    public float probability;
}
public class NaveEnemigo : Nave
{
    // public GameObject prefabLetOnDeath;
    public PrefatProbability[] prefatAndProbabilities;

    private float maxProbability = 0;
    protected override void Initialize()
    {
        base.Initialize();
        foreach (PrefatProbability pp in prefatAndProbabilities)
        {
            maxProbability += pp.probability;
        }
    }

    private GameObject selectRandomPrefab(){
        
        float randomNumber = Random.Range(0f, maxProbability);
        float actualAcumulate = 0f;
        print("Random: "+randomNumber);
        foreach (PrefatProbability pp in prefatAndProbabilities)
        {
            actualAcumulate+=pp.probability;
            if(randomNumber<=actualAcumulate){
                return pp.prefabLetOnDeath;
            }
        }
        return prefatAndProbabilities[prefatAndProbabilities.Length-1].prefabLetOnDeath;
    }
    public float scoreOnKill = 10;
    protected override void OnDeath()
    {
        base.OnDeath();
        if(prefatAndProbabilities ==null || prefatAndProbabilities.Length==0){
            return;
        }
        Instantiate(selectRandomPrefab(), transform.position, Quaternion.identity);
        GlobalObjects.Instance.gameController.IncreaseScore(scoreOnKill);
    }
}
