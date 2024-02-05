using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    // public GameObject PauseText;
    private bool isPause;
    public GameObject MenuPauseText;
    private bool isMenuPause;

    // Start is called before the first frame update
    void Start()
    {
        isPause = false;
        isMenuPause = false;
        MenuPauseText.gameObject.SetActive(isMenuPause);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)&&isPause==false)
        {
            Pausa();
        }
        else if (isPause == true)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                UnPausa();
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
    }

    private void Pausa()
    {
        Time.timeScale = 0f;
        // PauseText.gameObject.SetActive(isPause);
        isPause = true;
        isMenuPause = true;
        MenuPauseText.gameObject.SetActive(isMenuPause);
    }
    private void UnPausa()
    {
        Time.timeScale = 1f;
        // PauseText.gameObject.SetActive(isPause);
        isPause = false;
        isMenuPause = false;
        MenuPauseText.gameObject.SetActive(isMenuPause);
    }
    private void ReStart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void Quit()
    {
        //Cargar Menu
    }
}
