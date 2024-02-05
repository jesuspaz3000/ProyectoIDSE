using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVelocity : MonoBehaviour
{
    private Rigidbody rb;
    // public GameObject nave;
    public Vector3 velocity;
    // public float speedV = 20.0f;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if(rb == null){
            Debug.LogError("RigidBody is requided for this script");
        }
    }
    void Start(){
        rb.velocity = velocity;
    }
    // public void SetNaveVelocity(Vector3 naveVelocity)
    // {
    //     rb.velocity = transform.forward*speedV + naveVelocity;
    // }
}
