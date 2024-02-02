using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    private float initialSpeed = 30;

    private Rigidbody rb; 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Asegúrate de tener un Rigidbody adjunto
        if (rb == null)
        {
            Debug.LogError("Se requiere un Rigidbody en el objeto.");
        }

        // Establece la velocidad constante
        rb.velocity = transform.up * initialSpeed;

        Destroy(gameObject, 10);
    }

    void Update()
    {
        // transform.Translate(Vector3.up * initialSpeed * Time.deltaTime);
    }

    // void OnCollisionEnter(Collision other)
    // {
    //     print("OnCollisionEnter");
    //     if (other.gameObject.CompareTag("Nave"))
    //     {
    //         Explode();
    //     }
    // }

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
        print("Explosión");
        // Ajusta la posición de las partículas y activa la explosión

        GlobalParticleSystems.Instance.PlayExplosion(transform.position);
        
        // Destruye la bala
        Destroy(gameObject);
    }
}
