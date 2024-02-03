using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverAsteroide : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = -5.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.forward*speed;
    }
}
