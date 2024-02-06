using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class Nave : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float health = 100;
    public GameObject explosionNavePrefab;
    [SerializeField]
    public AudioClip explosionSound;

    public Transform HealthBar;

    private float maxHealt;

    void Start()
    {
        // explosionSound = GetComponent<AudioClip>();
        Initialize();
        UpdateHealthBar();
        
    }

    virtual protected void Initialize()
    {
        maxHealt = health;
    }

    // void Update()
    // {

    // }
    public float getHealth()
    {
        return health;
    }
    public void decreaseHealth(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            OnDeath();
        }
        UpdateHealthBar();
    }
    public void increaseHealth(float damage)
    {
        health += damage;
        UpdateHealthBar();
    }

    virtual protected void OnDeath()
    {
        explode();
        if (CompareTag("Player"))
        {
            return;
        }
        // explosionSound.Play();
        AudioSource.PlayClipAtPoint(explosionSound, transform.position);
        Destroy(gameObject, 0f);
    }
    virtual protected void explode()
    {
        if (explosionNavePrefab != null)
        {
            Instantiate(explosionNavePrefab, transform.position, transform.rotation);
        }
    }

    private void UpdateHealthBar()
    {
        if (HealthBar != null)
            HealthBar.localScale = new Vector3(1f / maxHealt * health, 1, 1);
    }
}
