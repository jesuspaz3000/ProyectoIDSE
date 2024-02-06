using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class RotativeRandomPrefabSpawner : PrefabsSpawner
{
    public Vector3 maxAngle;
    
    private int actualObject = 0;
    Vector3 initialRotation;
    protected override void Initicalize()
    {
        base.Initicalize();
        initialRotation = transform.rotation.eulerAngles;
        print(objectsForEachWave);
    }
    override protected Vector3 positionsSpawnGenerator(){
        return getRandomPositionInTrigger();
    }
    private Vector3 getRandomPositionInTrigger(){
        actualObject = actualObject % objectsForEachWave;
        // if(actualObject >= objectsForEachWave){
        //     actualObject = 0;
        //     transform.rotation = initialRotation;
        // }
        // actualObject = actualObject % objectsForEachWave;

        float t = (float)actualObject / (float) (objectsForEachWave-1);
        Mathf.PingPong(t, 1f);
        print("actualObject: "+actualObject);
        print("objectsForEachWave: "+objectsForEachWave);
        print("t: "+t);

        // Quaternion fin = Quaternion.Euler(maxAngle);

        Quaternion rotationIntermedia = Quaternion.Euler(Vector3.Lerp(initialRotation, initialRotation + maxAngle, t));
        transform.rotation = rotationIntermedia;
        
        print("initialRotation: "+initialRotation);
        print("fin: "+maxAngle);
        print("transform.rotation: "+transform.rotation);

        actualObject++;

        return transform.position;
    }
}
