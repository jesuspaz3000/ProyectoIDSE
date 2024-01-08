using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject bullet;
    public float shotForce = 1500f;
    public float shotRate = 0.5f;
    private float shotRateTime = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > shotRateTime)
        {
            shotRateTime = Time.time + shotRate;
            GameObject newBullet;

            // Asumiendo que la bala debe rotarse 90 grados en el eje X para estar horizontal
            // Multiplicamos primero por la rotación que orienta la bala correctamente
            Quaternion bulletOrientation = Quaternion.Euler(90, 0, 0);

            // Luego, aplicamos la rotación del spawnPoint para alinearla con la dirección de la nave
            Quaternion finalRotation = spawnPoint.rotation * bulletOrientation;

            newBullet = Instantiate(bullet, spawnPoint.position, finalRotation);

            // Aplicamos la fuerza al Rigidbody si existe uno en la bala
            Rigidbody rb = newBullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(spawnPoint.forward * shotForce);
            }
        }
    }
}
