using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creditos : MonoBehaviour
{
    public RectTransform creditsImage; // Asegúrate de que este componente es un RectTransform
    public float scrollSpeed = 30f; // Velocidad a la que se desplazan los créditos
    public float startPositionY; // La posición inicial en Y
    public float endPositionY; // La posición Y donde los créditos deben detenerse y ocultarse

    private bool isScrolling; // Controla si se está mostrando el desplazamiento

    private void Start()
    {
        ResetCredits();
    }

    public void ShowCredits()
    {
        if (!isScrolling)
        {
            // Habilita la imagen de los créditos para que comience el desplazamiento.
            creditsImage.gameObject.SetActive(true);
            isScrolling = true;
        }
    }

    private void Update()
    {

        // Comprobar si se presiona la tecla Escape y los créditos están activos
        if (Input.GetKeyDown(KeyCode.Escape) && isScrolling)
        {
            ResetCredits();
            return; // Salir del Update para evitar que se ejecute el resto del código
        }

        if (isScrolling)
        {
            creditsImage.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);

            if (creditsImage.anchoredPosition.y >= endPositionY)
            {
                // Oculta y resetea la posición de los créditos para que estén listos para la próxima vez.
                ResetCredits();
            }
        }
    }

    private void ResetCredits()
    {
        creditsImage.anchoredPosition = new Vector2(creditsImage.anchoredPosition.x, startPositionY);
        creditsImage.gameObject.SetActive(false);
        isScrolling = false;
    }
}
