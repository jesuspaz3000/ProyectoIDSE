using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class SeguirObjeto : MonoBehaviour
{
    public GameObject target;
    public bool x, y, z;

    private Vector3 offset;
    void Start()
    {
        offset = transform.position - target.transform.position;
    }

    void Update()
    {
        Vector3 newPosition = transform.position;
        // Vector3 toPosition = transform.position + offset
        if (x)
        {
            newPosition.x = target.transform.position.x + offset.x;
        }
        if (y)
        {
            newPosition.y = target.transform.position.y + offset.y;
        }
        if (z)
        {
            newPosition.z = target.transform.position.z + offset.z;
        }
        transform.position = newPosition;
    }
}
