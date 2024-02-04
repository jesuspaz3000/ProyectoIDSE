using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Timeline;
using TMPro;
using System;
using Unity.VisualScripting;

public class ShooterPlayerPrincipal : ShooterPlayer
{

    public TextMeshPro textoTiempoDisparo;

    override protected float tiempoPasadoDesdeUltimaBala
    {
        get { return _tiempoPasadoDesdeUltimaBala; }
        set
        {
            // Solo actualiza el valor si es diferente al valor actual
            if (_tiempoPasadoDesdeUltimaBala != value)
            {
                _tiempoPasadoDesdeUltimaBala = value;
                // Notifica a los observadores que el valor ha cambiado
                OnTimerChange(_tiempoPasadoDesdeUltimaBala);
            }
        }
    }
    override protected void Shot(){
        GlobalObjects.Instance.gameController.DecreaseEnergy(bulletPrefab.GetComponent<Shot>().energyRequired);
        Instantiate(bulletPrefab, bulletSpawner.position, bulletSpawner.rotation);
    }
    private void OnTimerChange(float timeRest)
    {
        textoTiempoDisparo.text = "" + timeRest;
    }
}
