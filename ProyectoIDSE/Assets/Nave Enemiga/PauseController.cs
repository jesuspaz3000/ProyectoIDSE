using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    public Text PauseText;
    private bool Pause;

    public Text MenuPauseText;
    private bool MenuPause;

    // Start is called before the first frame update
    void Start()
    {
        Pause = false;
        MenuPause = false;
        MenuPauseText.gameObject.SetActive(MenuPause);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)&&Pause==false)
        {
            Pausa();
        }
        else if (Pause == true)
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
        PauseText.gameObject.SetActive(Pause);
        Pause = true;
        MenuPause = true;
        MenuPauseText.gameObject.SetActive(MenuPause);
    }
    private void UnPausa()
    {
        Time.timeScale = 1f;
        PauseText.gameObject.SetActive(Pause);
        Pause = false;
        MenuPause = false;
        MenuPauseText.gameObject.SetActive(MenuPause);
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
