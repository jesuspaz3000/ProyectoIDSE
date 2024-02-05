using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;

public class ShotScaling : Shot
{
    public Vector3 incrementoEscala = new Vector3(0.1f, 0.1f, 0.1f);
    private Vector3 initialEscale = new Vector3(1,1,1);

    void Update()
    {
        transform.localScale = transform.localScale + incrementoEscala * Time.deltaTime;
    }

    void Start()
    {
        initialEscale = transform.localScale;
        rb = GetComponent<Rigidbody>();
        if (rb == null) Debug.LogError("Se requiere un Rigidbody en el objeto.");
        if (StartShotPrefab == null) Debug.LogError("Se requiere un StartShotParticles en el objeto.");
        if (ExplosionPrefab == null) Debug.LogError("Se requiere un ExplosionParticles en el objeto.");

        Initialize();
    }
}
