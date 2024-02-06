using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    public float[] stopPositions; // Posiciones en el eje Y donde la cámara se detendrá
    public float speed = 5f; // Velocidad de movimiento de la cámara
    public float pauseDuration = 2f; // Duración de la pausa en cada posición

    private IEnumerator Start()
    {
        foreach (float stopPosition in stopPositions)
        {
            // Mover la cámara hacia el punto de detención actual en el eje Y
            while (Mathf.Abs(transform.position.y - stopPosition) > 0.1f)
            {
                // Crea un nuevo vector de posición para la cámara
                Vector3 newPosition = new Vector3(transform.position.x, Mathf.MoveTowards(transform.position.y, stopPosition, speed * Time.deltaTime), transform.position.z);
                
                // Asigna la nueva posición a la cámara
                transform.position = newPosition;
                yield return null; // Esperar al siguiente frame
            }

            // Esperar en la posición actual
            yield return new WaitForSeconds(pauseDuration);
        }

        // Acciones después de las pausas, por ejemplo, terminar la animación
    }
}