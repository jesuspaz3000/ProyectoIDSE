using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    // explosion
    public GameObject explosionPrefab;

    [SerializeField]
    private AudioClip explosionSound;
    public float damage = 5;
    
    public float scoreOnDestroy;

    void Start()
    {
        // explosionSound = GetComponent<AudioClip>();
        // explosionSound.playOnAwake = false;
    }
    void OnTriggerEnter(Collider other)
    {
        Nave nave = other.GetComponentInParent<Nave>();
        print("OnTriggerEnter: "+ other.tag + "-> "+ nave);

        if(nave != null)
        // if(other.CompareTag("Nave") || other.CompareTag("Player"))
        {   
            // explosionSound.Play();
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
            nave.decreaseHealth(damage);
            
            // GlobalObjects.Instance.gameController.DecreaseVida(damage);
           
        }
        if (other.CompareTag("Disparo"))
        {
            //Disminuir vida y destruirse
            // gameController.IncreaseScore(scoreValue);
            // explosionSound.Play();
            GlobalObjects.Instance.gameController.IncreaseScore(scoreOnDestroy);
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else
        {
            return;
        }
    }
    virtual protected void OnContact(Collider other){

    } 
    void OnDestroy(){
        // explosionSound.Play();
        // GlobalObjects.Instance.audioSource.PlayOneShot();
        AudioSource.PlayClipAtPoint(explosionSound, transform.position);
    }
}
