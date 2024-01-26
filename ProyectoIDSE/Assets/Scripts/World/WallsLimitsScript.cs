using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsLimitsScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform objetoObjetivo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, objetoObjetivo.position.y, transform.position.z);;
    }
}
