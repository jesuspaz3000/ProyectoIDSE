using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Scape : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
