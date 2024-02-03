using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ParticleEffectGraph : ParticleEffect
{
    
    private VisualEffect particleS;
    void Start()
    {
        particleS = GetComponent<VisualEffect>();
    }
    public override void play()
    {
        particleS.Play();
    }
}