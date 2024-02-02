using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Timeline;
using TMPro;
using System;
using Unity.VisualScripting;

public class Shooter : MonoBehaviour
{
    private bool isShooting = false;
    private bool shot = true;
    public GameObject bulletPrefab;
    public TextMeshPro textoTiempoDisparo;

    const string BULLET_SPAWNER = "BulletSpawner";

    private float bulletReloadTime = 0.5f;
    private float _tiempoPasadoDesdeUltimaBala = 0.5f;
    public float tiempoPasadoDesdeUltimaBala
    {
        get { return _tiempoPasadoDesdeUltimaBala; }
        set
        {
            // Solo actualiza el valor si es diferente al valor actual
            if (_tiempoPasadoDesdeUltimaBala != value)
            {
                _tiempoPasadoDesdeUltimaBala = value;
                // Notifica a los observadores que el valor ha cambiado
                OnTimerChange(_tiempoPasadoDesdeUltimaBala);
            }
        }
    }



    private Transform bulletSpawner;
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
                    Instantiate(bulletPrefab, bulletSpawner.position, bulletSpawner.rotation);
                    shot = true;
                    GlobalParticleSystems.Instance.PlayStartLightShotExplosion(bulletSpawner.position);
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

    private void OnTimerChange(float timeRest)
    {
        textoTiempoDisparo.text = "" + timeRest;
    }
}
