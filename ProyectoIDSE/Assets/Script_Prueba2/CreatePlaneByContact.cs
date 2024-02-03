using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlaneByContact : MonoBehaviour
{
    public GameObject planePrefap;
    private bool nuevoPlano = false;
    // Start is called before the first frame update
    void Update()
    {
        // Obtén la posición actual de la nave
        if (GameObject.FindWithTag("Player")!=null)
        {
            float posicionNaveZ = GameObject.FindWithTag("Player").transform.position.z;

            // Verifica si la nave ha pasado la mitad del plano actual
            if (posicionNaveZ > transform.position.z - 10 && nuevoPlano == false)
            {
                // Crea un nuevo plano de fondo
                GameObject nuevoPlanoFondo = Instantiate(planePrefap, new Vector3(0, 0, transform.position.z + 60), Quaternion.identity);
                nuevoPlano = true;

            }
            else if (posicionNaveZ > transform.position.z + 45)
            {
                // Destruye el plano actual
                Destroy(gameObject);
            }
        }
    }
}
