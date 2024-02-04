
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;

abstract public class Spawner : MonoBehaviour
{
    abstract public GameObject Spawn();
    abstract public GameObject SpawnOnPosition(Vector3 position);    
}
