using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class SpawnerBetweenObjects : PrefabsSpawner
{
    public GameObject FirtsObject;
    public GameObject SecondObject;

    private int actualObject = 0;
    protected override void Initicalize()
    {
        base.Initicalize();
    }
    override protected Vector3 positionsSpawnGenerator(){
        return getRandomPositionInTrigger();
    }
    private Vector3 getRandomPositionInTrigger(){

        actualObject = actualObject % objectsForEachWave;

        Vector3 relativePosition = (SecondObject.transform.position - FirtsObject.transform.position) / ((float) objectsForEachWave -1) * (float) actualObject;

        actualObject++;
        return FirtsObject.transform.position + relativePosition;
    }
}
