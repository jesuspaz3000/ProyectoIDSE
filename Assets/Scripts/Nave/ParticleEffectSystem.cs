using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffectSystem : ParticleEffect
{
    
    private ParticleSystem particleS;
    void Start()
    {
        particleS = GetComponentInChildren<ParticleSystem>();
        if (particleS == null) Debug.LogError("Se requiere un ParticleSystem en el objeto.");
    }
    public override void play()
    {
        // particleS.Play();
    }
}
