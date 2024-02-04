using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 200;
    public GameObject explosionNavePrefab;
    // void Start()
    // {

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
        Destroy(gameObject, 0.1f);
    }
    virtual protected void explode(){
        if (explosionNavePrefab != null)
        {
            Instantiate(explosionNavePrefab, transform.position, transform.rotation);
        }
    }
}