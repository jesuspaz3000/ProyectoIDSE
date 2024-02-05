using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveEnemigo : Nave
{
    public GameObject prefabLetOnDeath;
    public float scoreOnKill = 10;
    protected override void OnDeath()
    {
        base.OnDeath();
        Instantiate(prefabLetOnDeath, transform.position, Quaternion.identity);
        GlobalObjects.Instance.gameController.IncreaseScore(scoreOnKill);
    }
}
