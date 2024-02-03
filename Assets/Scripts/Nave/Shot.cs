using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shot : MonoBehaviour
{
    private float InitialSpeed = 30;
    public GameObject StartShotPrefab;
    public GameObject ExplosionPrefab;

    private ParticleEffect startShotParticles;
    private ParticleEffect explosionParticles;


    protected Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null) Debug.LogError("Se requiere un Rigidbody en el objeto.");
        if (StartShotPrefab == null) Debug.LogError("Se requiere un StartShotParticles en el objeto.");
        if (ExplosionPrefab == null) Debug.LogError("Se requiere un ExplosionParticles en el objeto.");

        Initialize();
    }

    protected void Initialize()
    {   
        PlayStartShotExplosion();
        rb.velocity = transform.up * InitialSpeed;
        Destroy(gameObject, 10);
    }

    void OnTriggerEnter(Collider other)
    {
        print("OnTriggerEnter");
        if (other.gameObject.CompareTag("Nave"))
        {
            Explode();
        }
    }

    void Explode()
    {
        print("Explosión: " + transform.position);
        PlayShotFinalExplosion();
        Destroy(gameObject);
    }

    private void PlayStartShotExplosion(){
        GameObject explosion = Instantiate(StartShotPrefab, transform.position, Quaternion.identity);
        startShotParticles = explosion.GetComponentInChildren<ParticleEffect>();
        if (startShotParticles == null) Debug.LogError("Se requiere un startShotParticles en el objeto.");
        // startShotParticles.play(); 
    }
    private void PlayShotFinalExplosion(){
        GameObject explosion = Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
        explosionParticles = explosion.GetComponentInChildren<ParticleEffect>();
        if (explosionParticles == null) Debug.LogError("Se requiere un explosionParticles en el objeto.");
        explosionParticles.play();
    }

}
