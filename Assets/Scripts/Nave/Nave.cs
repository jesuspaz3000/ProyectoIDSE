using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 100;
    public GameObject explosionNavePrefab;
    [SerializeField]
    public AudioClip explosionSound;
    // void Start()
    // {
    //     // explosionSound = GetComponent<AudioClip>();
    // }
    // void Update()
    // {

    // }

    public void decreaseHealth(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            OnDeath();
        }

    }
    public void increaseHealth(float damage)
    {
        health += damage;
    }

    virtual protected void OnDeath()
    {
        explode();
        if(CompareTag("Player")){
            return;
        }
        // explosionSound.Play();
        AudioSource.PlayClipAtPoint(explosionSound, transform.position);
        Destroy(gameObject, 0f);
    }
    virtual protected void explode(){
        if (explosionNavePrefab != null)
        {
            Instantiate(explosionNavePrefab, transform.position, transform.rotation);
        }
    }
}
