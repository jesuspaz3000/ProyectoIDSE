using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlaneByContact : MonoBehaviour
{
    public GameObject planePrefab;
    private GameObject followObject;
    
    private bool nuevoPlano = false;
    private float planeSize;
    public float porcentajeCreacion = 0.8f;

    void Start()
    {
        // Obtén el tamaño del objeto actual en el eje vertical
        planeSize = transform.localScale.y*20;
        followObject = GlobalObjects.Instance.NavePrincipal;
    }

    void Update()
    {
        float posicionNaveY = followObject.transform.position.y;

        // Calcula la posición Y en la que se debe crear un nuevo plano
        float nuevaPosicionY = transform.position.y + planeSize;

        // Verifica si la nave ha pasado la posición Y para crear un nuevo plano
        if (posicionNaveY > transform.position.y + ((planeSize * porcentajeCreacion) - planeSize / 2)  && !nuevoPlano)
        {
            Quaternion rotation = planePrefab.transform.rotation;
            GameObject nuevoPlanoFondo = Instantiate(planePrefab, new Vector3(0, nuevaPosicionY, transform.position.z), rotation);
            nuevoPlano = true;
        }
        else if (posicionNaveY > transform.position.y + planeSize)
        {
            // Destruye el plano actual si la nave lo ha pasado completamente
            Destroy(gameObject);
        }
    }
}