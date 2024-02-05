using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinnerControllerTrigger : MonoBehaviour
{
    public Collider WinTriger;
    public GameObject menuWin;

    private bool isWinMenu;
    private Vector3 initPosition;
    private float distanciaInicial;
    [NonSerialized]
    private float distance;
    [NonSerialized]
    public float distanceNormalized;


    void Start()
    {
        menuWin.SetActive(false);
        initPosition = GlobalObjects.Instance.NavePrincipal.transform.position;

        distanciaInicial = (transform.position - initPosition).magnitude;
    }
    void Update()
    {
        if (isWinMenu)
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                NextLevel();
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                ReStart();
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                Quit();
            }
        
        }
        distance = distanciaInicial - (transform.position - GlobalObjects.Instance.NavePrincipal.transform.position).magnitude;
        distanceNormalized = 1/distanciaInicial * distance;
        GlobalObjects.Instance.playerGameInterface.progreso.localScale = new Vector3(distanceNormalized, 1,1);
    }

    

    private void Quit()
    {
        throw new NotImplementedException();
    }

    private void NextLevel()
    {
        throw new NotImplementedException();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            WinLevel();
        }
    }

    private void WinLevel()
    {
        isWinMenu = true;
        Time.timeScale = 0f;
        menuWin.SetActive(isWinMenu);
    }
    private void ReStart()
    {
        isWinMenu = false;
        Time.timeScale = 1f;
        menuWin.SetActive(isWinMenu);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
