using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotateAsteroide : MonoBehaviour
{
    public float aV=1.0f;
    private Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        rb.angularVelocity=Random.insideUnitSphere * aV;
    }
}
