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
    // public float puntuacionTotal = 0;
    private float tiempoInicio = 0;
    // private string tiempoTexto = "00:00:0000";
    public float tiempo = 0;
    // public float vida = 4;
    public GameObject[] disparos;
    public int disparoActual = 0;
    public GameObject[] disparosEspeciales;
    public int disparoEspecialActual = 0;

    private PlayerGameInterface playerinterface;
    private Nave navePrincipal;
    private ShooterPlayer shooterNavePrincipal;

    private float maxVida = 100;
    private float maxEnergy = 100;
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

        maxVida = navePrincipal.health;
        maxEnergy = energia;
    }

    void Update()
    {
        tiempo = Time.time - tiempoInicio;
        UpdateCanvasParameters();

        if (navePrincipal.health <= 0)
        {
            GlobalObjects.Instance.gameOverController.GameOver();
        }
    }
    public void IncreaseScore(float score)
    {
        puntuacionNivel += score;
        GlobalObjetcsInScenes.Instance.totalScore += score;
    }
    public void DecreaseScore(float score)
    {
        puntuacionNivel -= score;
        GlobalObjetcsInScenes.Instance.totalScore -= score;
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

        playerinterface.ataqueTipo1Text.SetActive(disparoActual == 0);
        playerinterface.ataqueTipo2Text.SetActive(disparoActual == 1);
        playerinterface.ataqueTipo3Text.SetActive(disparoActual == 2);
        playerinterface.ataqueEspecialTipo1Text.SetActive(false);
        playerinterface.ataqueEspecialTipo2Text.SetActive(false);
        playerinterface.ataqueEspecialTipo3Text.SetActive(false);
    }
    public void ChangeSpecialShotType(int n)
    {
        disparoEspecialActual = n;
        // shooterNavePrincipal.bulletPrefab = disparos[n];

        playerinterface.ataqueTipo1Text.SetActive(false);
        playerinterface.ataqueTipo2Text.SetActive(false);
        playerinterface.ataqueTipo3Text.SetActive(false);
        playerinterface.ataqueEspecialTipo1Text.SetActive(disparoActual == 0);
        playerinterface.ataqueEspecialTipo2Text.SetActive(disparoActual == 1);
        playerinterface.ataqueEspecialTipo3Text.SetActive(disparoActual == 2);
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
        // Vector3 currentEnergyBar = playerinterface.energiaText.transform.localScale;
        // currentEnergyBar.x = 1f / maxEnergy * energia = 100;
        playerinterface.energiaText.localScale = new Vector3(1f / maxEnergy * energia, 1, 1);

        playerinterface.puntuacionNivelText.text = "" + puntuacionNivel;
        playerinterface.puntuacionTotalText.text = "" + GlobalObjetcsInScenes.Instance.totalScore;
        // playerinterface.tiempoText.text = "+Tiempo: " + FormatoTiempo(tiempo);
        playerinterface.tiempoText.text = "T: " + FormatoTiempo(tiempo);

        Vector3 currentVidaBarra = playerinterface.vidaNaveText.transform.localScale;
        // currentVidaBarra.x = 1f / maxVida * navePrincipal.health;
        playerinterface.vidaNaveText.localScale = new Vector3(1f / 1f / maxVida * navePrincipal.health, 1, 1); ;

        // playerinterface.vidaNaveText.text = "+Vida nave: "+navePrincipal.health;
    }
}
