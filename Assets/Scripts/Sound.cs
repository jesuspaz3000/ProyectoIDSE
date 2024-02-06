using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioClip soundClip; // Asigna este clip en el Inspector
    private AudioSource audioSource;

    void Start()
    {
        // Obtener el componente AudioSource del GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Si no hay AudioSource, lo añadimos al GameObject
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Configura el AudioSource
        audioSource.clip = soundClip;
        audioSource.playOnAwake = false; // Evita que el sonido se reproduzca automáticamente al iniciar
    }

    // Método público para reproducir el sonido
    public void PlaySound()
    {
        if (audioSource != null && soundClip != null)
        {
            audioSource.PlayOneShot(soundClip); // Reproduce el sonido una vez
        }
    }
}
