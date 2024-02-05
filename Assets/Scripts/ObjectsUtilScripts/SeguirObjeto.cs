using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class SeguirObjeto : MonoBehaviour
{
    public GameObject target;
    public bool x,y,z;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = target.transform.position;
        if(x){
            newPosition.x = transform.position.x;
        }
        if(y){
            newPosition.x = transform.position.y;
        }
        if(z){
            newPosition.x = transform.position.z;
        }
        transform.position = target.transform.position;
    }
}
