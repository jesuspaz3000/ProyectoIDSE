using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Timeline;
using System;
using Unity.VisualScripting;

public class ShooterPlayer : MonoBehaviour
{
    private bool isShooting = false;
    private bool shot = true;
    public GameObject bulletPrefab;
    

    const string BULLET_SPAWNER = "BulletSpawner";

    public float bulletReloadTime = 0.8f;
    protected float _tiempoPasadoDesdeUltimaBala = 0.5f;
    
    virtual protected float tiempoPasadoDesdeUltimaBala
    {
        get { return _tiempoPasadoDesdeUltimaBala; }
        set
        {
            // Solo actualiza el valor si es diferente al valor actual
            if (_tiempoPasadoDesdeUltimaBala != value)
            {
                _tiempoPasadoDesdeUltimaBala = value;
            }
        }
    }



    protected Transform bulletSpawner;
    private Rigidbody rb;

    void Start()
    {
        bulletSpawner = transform.GetChild(0);

        // if (bulletSpawner == null)
        // {
        //     Debug.LogError("No se encontró el hijo con el nombre especificado: " + BULLET_SPAWNER);
        // }
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isShooting || tiempoPasadoDesdeUltimaBala < bulletReloadTime)
        {
            tiempoPasadoDesdeUltimaBala += Time.deltaTime;
            if (isShooting)
            {
                if (tiempoPasadoDesdeUltimaBala > bulletReloadTime)
                {
                    Shot();
                    shot = true;
                }
            }

        }
        if(isShooting && shot){
            tiempoPasadoDesdeUltimaBala = 0;
            shot=false;
        }
    }

    public void StartShooting()
    {
        isShooting = true;
    }

    public void StopShooting()
    {
        isShooting = false;
    }

    virtual protected void Shot(){
        Instantiate(bulletPrefab, bulletSpawner.position, bulletSpawner.rotation);
        // print("shot normal");
    }
}
