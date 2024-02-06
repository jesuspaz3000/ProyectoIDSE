using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salir : MonoBehaviour
{
    public GameObject objetoParaOcultar; // Asigna aquí el objeto que quieres ocultar.

    // Se llama en cada frame.
    void Update()
    {
        // Comprueba si se presiona la tecla Escape.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Si el objeto está activo, lo desactivamos para ocultarlo.
            if (objetoParaOcultar.activeInHierarchy)
            {
                objetoParaOcultar.SetActive(false);
            }
        }
    }

    // Llama a esta función desde un botón para salir del juego.
    public void SalirDelJuego()
    {
        Application.Quit(); // Salir del juego.

        // Si está en el editor de Unity, detiene la reproducción.
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
