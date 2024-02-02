using UnityEngine;

public class GlobalParticleSystems : MonoBehaviour
{
    // Singleton instance
    private static GlobalParticleSystems _instance;
    public static GlobalParticleSystems Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GlobalParticleSystems>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject("GlobalParticleSystems");
                    _instance = obj.AddComponent<GlobalParticleSystems>();
                }
            }
            return _instance;
        }
    }

    public ParticleSystem explosionParticles;
    public ParticleSystem startShotParticles;

    void Start()
    {
        // Example: You can preload or configure your particle systems here
    }

    void Update()
    {
        // Example: You can update particle systems here if needed
    }

    public void PlayExplosion(Vector3 position)
    {
        // Instantiate and play the explosion particle system
        ParticleSystem explosion = Instantiate(explosionParticles, position, Quaternion.identity);
        explosion.Play();

        // Emitir las partículas en una ráfaga
        
        // explosionParticles.transform.position = position;
        // explosionParticles.Play();
        // explosionParticles.Emit(3);
        print("  _> "+explosionParticles.transform.position);
        // Optionally, you can configure or manipulate the explosion particle system here
    }
    public void PlayStartLightShotExplosion(Vector3 position){
        
        ParticleSystem explosion = Instantiate(startShotParticles, position, Quaternion.identity);
        explosion.Play();
    }
}
