using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveEnemigo : Nave
{
    public GameObject prefabLetOnDeath;
    protected override void OnDeath()
    {
        base.OnDeath();
        Instantiate(prefabLetOnDeath, transform.position, Quaternion.identity);
        
    }
}
