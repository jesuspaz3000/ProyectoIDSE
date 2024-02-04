using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RutinaEnemigo : MonoBehaviour
{
    [SerializeField] private float velodidadMovimiento;
    [SerializeField] private float rangoZ = 20f;
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
        transform.position = Vector3.MoveTowards(transform.position, nuevaPosicion, velodidadMovimiento * Time.deltaTime);
        if (Vector3.Distance(transform.position, nuevaPosicion) < distaniaMinima)
        {
            InicializarNuevaPosicionYDistanciaMinima();
        }
    }
    void InicializarNuevaPosicionYDistanciaMinima()
    {
        float nuevaPosicionX = Random.Range(-rangoX / 2f, rangoX / 2f);
        float nuevaPosicionY = Random.Range(-rangoZ / 2f, rangoZ / 2f);
        nuevaPosicion = new Vector3(nuevaPosicionX, transform.position.y, nuevaPosicionY);

        distaniaMinima = Random.Range(1f,5f);
    }
}
