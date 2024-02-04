using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn;

    //tiempos de disparo
    public float delay;
    public float fireRate;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("Fire",delay,fireRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Fire() 
    {
        GameObject nuevoDisparo = Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        nuevoDisparo.GetComponent<Disparo_Move>().SetNaveVelocity(rb.velocity);
    }
}
