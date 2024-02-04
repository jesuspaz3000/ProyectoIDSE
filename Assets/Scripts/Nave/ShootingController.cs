using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    private ShooterPlayer shooter; // Referencia a la clase ShooterPlayer

    void Start()
    {
        shooter = GetComponent<ShooterPlayer>(); // Obtener la referencia del componente Shooter
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && GlobalObjects.Instance.gameController.energia > 0)
        {
            shooter.StartShooting(); // Habilitar el disparo mientras la tecla "espacio" esté presionada
        }
        else
        {
            shooter.StopShooting(); // Deshabilitar el disparo cuando la tecla "espacio" no esté presionada
        }
        
    }
}
