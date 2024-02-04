using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 200;
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    public void BeDamaged(float damage){
        health -= damage;
    }
}
