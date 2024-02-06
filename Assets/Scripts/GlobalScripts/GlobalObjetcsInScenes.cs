using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalObjetcsInScenes : MonoBehaviour
{
    
    public float totalScore = 0;
    private static GlobalObjetcsInScenes _instance;
    public static GlobalObjetcsInScenes Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GlobalObjetcsInScenes>();
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject("GlobalObjetcsInScenes");
                    _instance = singletonObject.AddComponent<GlobalObjetcsInScenes>();
                }
            }
            return _instance;
        }
    }


    // Para objetos en todas las escenas

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            
            // foreach (GameObject obj in objectsToStore)
            // {
            //     DontDestroyOnLoad(obj);
            // }
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void DoSomething()
    {
        Debug.Log("GlobalObjetcsInScenes is doing something!");
    }


    private int nivelActual;
    public void ChangeToScene_Menu(){
        SceneManager.UnloadSceneAsync(nivelActual);
        SceneManager.LoadScene(0);
        nivelActual = 0;
    }
    public void ChangeToScene_Level_1(){
        SceneManager.UnloadSceneAsync(nivelActual);
        SceneManager.LoadScene(1);
        nivelActual = 1;
    }
    public void ChangeToScene_Level_2(){
        SceneManager.UnloadSceneAsync(nivelActual);
        SceneManager.LoadScene(2);
        nivelActual = 2;
    }
    public void ChangeToScene_Level_3(){
        SceneManager.UnloadSceneAsync(nivelActual);
        SceneManager.LoadScene(3);
        nivelActual = 3;
    }
    public void ChangeToScene_Level_4(){
        SceneManager.UnloadSceneAsync(nivelActual);
        SceneManager.LoadScene(4);
        nivelActual = 4;
    }
    public void ChangeToScene_Level_5(){
        SceneManager.UnloadSceneAsync(nivelActual);
        SceneManager.LoadScene(5);
        nivelActual = 5;
    }

    public void ChangeToNextLevel(){

        SceneManager.UnloadSceneAsync(nivelActual);
        nivelActual++;
        SceneManager.LoadScene(nivelActual % 6);
    }
}
