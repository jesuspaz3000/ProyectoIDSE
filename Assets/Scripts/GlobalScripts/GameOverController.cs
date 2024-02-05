using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    // public Text restartText;
    private bool restart;
    public GameObject gameOverText;
    private bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        restart = false;
        gameOver = false;
        gameOverText.gameObject.SetActive(gameOver);
    }

    // Update is called once per frame
    void Update()
    {
        if (restart && Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
            gameOver = false;
            gameOverText.gameObject.SetActive(gameOver);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverText.gameObject.SetActive(true);
        gameOver = true;
        restart = true;
    }
}
