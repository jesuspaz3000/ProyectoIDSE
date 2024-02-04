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
    public float vidas = 4;
    public bool[] disparos = {true,false,false};
    public int disparoActual = 0;
    public bool[] disparosEspeciales = {true,false,false};
    public int disparoEspecialActual = 0;

    private PlayerGameInterface playerinterface;
    private Nave navePrincipal;

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
    public float GetVida(){
        return vidas;
    }
    public void IncreaseVidas(float mount){
        vidas += mount;
    }
    public void DecreaseVidas(float mount){
        vidas -= mount;
        if(vidas <= 0){
            print("GameOver");
        }
    }

    public void ChangeShotType(int n)
    {
        disparos[disparoActual] = false;
        disparoActual = n;
        disparos[disparoActual] = true;
    }
    public void ChangeSpecialShotType(int n)
    {
        disparosEspeciales[disparoEspecialActual] = false;
        disparoActual = n;
        disparosEspeciales[disparoEspecialActual] = true;
    }
    public string FormatoTiempo(float tiempo)
    {
        int minutos = Mathf.FloorToInt(tiempo / 60f);
        int segundos = Mathf.FloorToInt(tiempo % 60f);
        int miliSegundos = Mathf.FloorToInt((tiempo * 1000) % 1000);

        return string.Format("{0:00}:{1:00}:{2:000}", minutos, segundos, miliSegundos);
    }

    private void UpdateCanvasParameters(){
        playerinterface.energiaText.text = "+Energia: "+energia ;
        playerinterface.puntuacionNivelText.text = "+Puntos del Nivel: "+puntuacionNivel ;
        playerinterface.puntuacionTotalText.text = "+Total: "+puntuacionTotal ;
        playerinterface.tiempoText.text = "+Tiempo: "+tiempoTexto ;
        playerinterface.vidaText.text = "+Vidas: "+vidas ;
        playerinterface.ataqueTipo1Text.text = "+Tipo 1: "+disparos[0].ToString() ;
        playerinterface.ataqueTipo2Text.text = "+Tipo 2: "+disparos[1].ToString() ;
        playerinterface.ataqueTipo3Text.text = "+Tipo 3: "+disparos[2].ToString() ;
        playerinterface.ataqueEspecialTipo1Text.text = "+Especial Tipo 1: "+ disparosEspeciales[0].ToString();
        playerinterface.ataqueEspecialTipo2Text.text = "+Especial Tipo 2: "+ disparosEspeciales[1].ToString();
        playerinterface.ataqueEspecialTipo3Text.text = "+Especial Tipo 3: "+ disparosEspeciales[2].ToString();

        playerinterface.vidaNaveText.text = "+Vida nave: "+navePrincipal.health;
    }
}
