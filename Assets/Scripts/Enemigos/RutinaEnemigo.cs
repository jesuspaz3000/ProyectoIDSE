using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RutinaEnemigo : MonoBehaviour
{
    [SerializeField] private float velodidadMovimiento;
    [SerializeField] private float rangoY = 20f;
    [SerializeField] private float rangoX = 60f;

    [SerializeField] private float distaniaMinima;
    private Vector3 nuevaPosicion;

    void Start()
    {
        InicializarNuevaPosicionYDistanciaMinima();
    }
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, nuevaPosicion) < distaniaMinima)
        {
            InicializarNuevaPosicionYDistanciaMinima();
        }
        transform.position = Vector3.MoveTowards(transform.position, nuevaPosicion, velodidadMovimiento * Time.deltaTime);
    }
    void InicializarNuevaPosicionYDistanciaMinima()
    {
        float nuevaPosicionX = Random.Range(-rangoX / 2f, rangoX / 2f);
        float nuevaPosicionY = Random.Range(-rangoY / 2f, rangoY / 2f);
        nuevaPosicion = new Vector3(nuevaPosicionX, nuevaPosicionY, transform.position.z);

        distaniaMinima = Random.Range(1f,5f);
    }
}
