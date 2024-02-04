using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class GameController : MonoBehaviour
{
    public float energia = 100;
    public float puntuacionNivel = 0;
    public float puntuacionTotal = 0;
    private float tiempoInicio = 0;
    private string tiempoTexto = "00:00:0000";
    public float tiempo = 0;
    // public float vida = 4;
    public GameObject[] disparos;
    public int disparoActual = 0;
    public GameObject[] disparosEspeciales;
    public int disparoEspecialActual = 0;

    private PlayerGameInterface playerinterface;
    private Nave navePrincipal;
    private ShooterPlayer shooterNavePrincipal;
    void Start()
    {
        // energia = 100;
        // puntuacionNivel = ;
        // puntuacionTotal = ;
        // tiempoInicio = ;
        // tiempoTexto = ;
        // tiempo = ;
        // vida = ;
        // disparos = ;
        // disparoActual = ;
        // disparosEspeciales = ;
        // disparoEspecialActual = ;

        tiempoInicio = Time.time;
        playerinterface = GlobalObjects.Instance.playerGameInterface;
        navePrincipal = GlobalObjects.Instance.NavePrincipal.GetComponent<Nave>();
        shooterNavePrincipal = GlobalObjects.Instance.NavePrincipal.GetComponent<ShooterPlayer>();
    }
    
    void Update()
    {
        tiempo = Time.time - tiempoInicio;
        string newTiempoTexto = FormatoTiempo(tiempo);
        if (tiempoTexto != newTiempoTexto)
        {
            tiempoTexto = newTiempoTexto;
            playerinterface.tiempoText.text = tiempoTexto;
        }

        UpdateCanvasParameters();
    }
    public void IncreaseScore(float score)
    {
        puntuacionNivel += score;
        puntuacionTotal += score;
    }
    public void DecreaseScore(float score)
    {
        puntuacionNivel -= score;
        puntuacionTotal -= score;
    }
    public void IncreaseEnergy(float energy)
    {
        energia += energy;
    }
    public void DecreaseEnergy(float energy)
    {
        energia -= energy;
    }
    public float GetVida()
    {
        return navePrincipal.health;
    }
    public void IncreaseVida(float mount)
    {
        navePrincipal.health += mount;
    }
    public void DecreaseVida(float mount)
    {
        navePrincipal.health -= mount;
        if (navePrincipal.health <= 0)
        {
            print("GameOver");
        }
    }

    public void ChangeShotType(int n)
    {
        disparoActual = n;
        shooterNavePrincipal.bulletPrefab = disparos[n];
    }
    public void ChangeSpecialShotType(int n)
    {
        disparoEspecialActual = n;
        // shooterNavePrincipal.bulletPrefab = disparos[n];
    }
    public string FormatoTiempo(float tiempo)
    {
        int minutos = Mathf.FloorToInt(tiempo / 60f);
        int segundos = Mathf.FloorToInt(tiempo % 60f);
        int miliSegundos = Mathf.FloorToInt((tiempo * 1000) % 1000);

        return string.Format("{0:00}:{1:00}:{2:000}", minutos, segundos, miliSegundos);
    }

    private void UpdateCanvasParameters()
    {
        playerinterface.energiaText.text = "+Energia: " + energia;
        playerinterface.puntuacionNivelText.text = "+Puntos del Nivel: " + puntuacionNivel;
        playerinterface.puntuacionTotalText.text = "+Total: " + puntuacionTotal;
        playerinterface.tiempoText.text = "+Tiempo: " + tiempoTexto;
        playerinterface.vidaText.text = "+Vida: " + navePrincipal.health;
        playerinterface.ataqueTipo1Text.text = "+Tipo 1: " + (disparoActual == 0);
        playerinterface.ataqueTipo2Text.text = "+Tipo 2: " + (disparoActual == 1);
        playerinterface.ataqueTipo3Text.text = "+Tipo 3: " + (disparoActual == 2);
        playerinterface.ataqueEspecialTipo1Text.text = "+Especial Tipo 1: " + (disparoEspecialActual == 1);
        playerinterface.ataqueEspecialTipo2Text.text = "+Especial Tipo 2: " + (disparoEspecialActual == 1);
        playerinterface.ataqueEspecialTipo3Text.text = "+Especial Tipo 3: " + (disparoEspecialActual == 1);

        // playerinterface.vidaNaveText.text = "+Vida nave: "+navePrincipal.health;
    }
}
