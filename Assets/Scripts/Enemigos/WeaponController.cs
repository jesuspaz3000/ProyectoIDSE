using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private ShooterPlayer shooter; 

    void Start()
    {
        shooter = GetComponent<ShooterPlayer>(); // Obtener la referencia del componente Shooter
        shooter.StartShooting();
    }

    
    void Update()
    {
        
    }
}