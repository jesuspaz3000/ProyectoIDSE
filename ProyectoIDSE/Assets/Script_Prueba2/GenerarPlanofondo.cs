using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject planoFondoPrefab;
    public Transform limitePlane;

    private bool generandoPlanoFondo = false;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > limitePlane.position.y && !generandoPlanoFondo)
        {
            generandoPlanoFondo = true;
            GenerarNuevoPlanoFondo();
        }
    }
    void GenerarNuevoPlanoFondo()
    {
        // Crear un nuevo plano de fondo justo después del LimitePlane
        GameObject nuevoPlanoFondo = Instantiate(planoFondoPrefab, new Vector3(0, limitePlane.position.y, 0), Quaternion.identity);
        // Ajustar el booleano para que no genere más planos hasta que se vuelva a tocar el límite
        generandoPlanoFondo = false;
    }
}
