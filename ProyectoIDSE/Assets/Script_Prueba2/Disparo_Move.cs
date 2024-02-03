using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo_Move : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject nave;
    public float speedV = 20.0f;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void SetNaveVelocity(Vector3 naveVelocity)
    {
        rb.velocity = transform.forward*speedV + naveVelocity;
    }
}
