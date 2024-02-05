using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
