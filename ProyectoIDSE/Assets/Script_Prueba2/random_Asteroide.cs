using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random_Asteroide : MonoBehaviour
{
    public float aV=1.0f;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Start()
    {
        rb.angularVelocity=Random.insideUnitSphere * aV;
    }
}
