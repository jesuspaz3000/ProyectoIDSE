using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem sistemaDeParticulas1;
    public ParticleSystem sistemaDeParticulas2;
    public ParticleSystem sistemaDeParticulas3;

    public AudioSource audioSource;
    // Rango de frecuencias bajas que representan los graves
    private int lowFrequency = 80;

    // Factor de escala para ajustar el tamaño de las partículas
    private float scaleMultiplier = 500.0f;

    private float ppos = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ReproducirParticulas(sistemaDeParticulas1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ReproducirParticulas(sistemaDeParticulas2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            // ReproducirParticulas(sistemaDeParticulas3);
            Vector3 pos = new Vector3(2f,ppos,2f); // the point of intersection between the particle and the enemy
            // Instantiate(prefab, pos, Quaternion.identity);
            // GameObject vfx = Instantiate(enemyHitVFX, pos, Quaternion.identity); // creating the explosion effect.
            // vfx.transform.parent = parentGameobject.transform; // this makes the new gameobjects children to my "VFX Parent" gameObject in my Hierarchy, for organizarion purposes
            sistemaDeParticulas2.transform.position = pos;
            
            
            sistemaDeParticulas2.Emit(10);


            ppos++;
        }

        // Obtén el volumen de la frecuencia baja en tiempo real
        float intensity = GetLowFrequencyVolume();

        // Modifica el tamaño de cada partícula individualmente
        ModifyParticleSize(intensity);
    }

    float GetLowFrequencyVolume()
    {
        // Obtén los datos del espectro de audio
        float[] spectrumData = new float[256];
        audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.BlackmanHarris);

        // Calcula el volumen de la frecuencia baja
        float volume = spectrumData[lowFrequency];

        // Normaliza el volumen para que esté en el rango [0, 1]
        volume = Mathf.Clamp01(volume);

        return volume;
    }

    void ModifyParticleSize(float intensity)
    {
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[sistemaDeParticulas3.particleCount];
        int particleCount = sistemaDeParticulas3.GetParticles(particles);

        // Modifica el tamaño de cada partícula basándose en la intensidad
        for (int i = 0; i < particleCount; i++)
        {
            particles[i].startSize = intensity * scaleMultiplier+1f;
        }

        // Aplica los cambios al sistema de partículas
        sistemaDeParticulas3.SetParticles(particles, particleCount);
    }


    void ReproducirParticulas(ParticleSystem sistemaDeParticulas)
    {
        sistemaDeParticulas.Play();
    }
}
