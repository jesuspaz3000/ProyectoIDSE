using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public float energyRequired = 1;
    public float InitialSpeed = 50;
    public GameObject StartShotPrefab;
    public AudioClip StartShotSound;
    public GameObject ExplosionPrefab;
    public AudioClip ExplosionSound;

    public float damage = 5;

    public bool destroyOnCollision = true;

    private ParticleEffect startShotParticles;
    private ParticleEffect explosionParticles;


    protected Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null) Debug.LogError("Se requiere un Rigidbody en el objeto.");
        // if (StartShotPrefab == null) Debug.LogError("Se requiere un StartShotParticles en el objeto.");
        // if (ExplosionPrefab == null) Debug.LogError("Se requiere un ExplosionParticles en el objeto.");

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
        // print("OnTriggerEnter: "+ other.tag+ );
        Nave nave = other.GetComponentInParent<Nave>();
        // print("OnTriggerEnter: "+ other.tag + "-> "+ nave);

        if(nave != null)
        // if (other.gameObject.CompareTag("Nave") || other.gameObject.CompareTag("Player"))
        {
            Explode();
            print("Explosion");
            
            // print(nave);
            // if(nave == null){
            // }else{
            nave.decreaseHealth(damage);
            // }
        }
    }

    void Explode()
    {
        print("Explosión: " + transform.position);
        PlayShotFinalExplosion();
        
        if(destroyOnCollision){
            Destroy(gameObject);
        }
    }

    private void PlayStartShotExplosion(){
        if(StartShotPrefab==null) return;
        
        AudioSource.PlayClipAtPoint(StartShotSound, transform.position);

        GameObject explosion = Instantiate(StartShotPrefab, transform.position, Quaternion.identity);
        startShotParticles = explosion.GetComponentInChildren<ParticleEffect>();
        if (startShotParticles == null) Debug.LogError("Se requiere un startShotParticles en el objeto.");
        startShotParticles.play(); 
    }
    private void PlayShotFinalExplosion(){
        if(ExplosionPrefab==null) return;

        AudioSource.PlayClipAtPoint(ExplosionSound, transform.position);

        GameObject explosion = Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
        explosionParticles = explosion.GetComponentInChildren<ParticleEffect>();
        if (explosionParticles == null) Debug.LogError("Se requiere un explosionParticles en el objeto.");
        explosionParticles.play();
    }

}
