using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Shooter shooter; // Referencia a la clase Shooter

    void Start()
    {
        shooter = GetComponent<Shooter>(); // Obtener la referencia del componente Shooter
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            shooter.StartShooting(); // Habilitar el disparo mientras la tecla "espacio" esté presionada
        }
        else
        {
            shooter.StopShooting(); // Deshabilitar el disparo cuando la tecla "espacio" no esté presionada
        }
    }
}
