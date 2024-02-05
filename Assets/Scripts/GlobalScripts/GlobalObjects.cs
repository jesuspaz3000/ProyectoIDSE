using UnityEngine;

public class GlobalObjects : MonoBehaviour
{
    private static GlobalObjects _instance;
    public GameObject NavePrincipal;
    public PlayerGameInterface playerGameInterface;
    public GameController gameController;

    public GameOverController gameOverController;
    public PauseController pauseController;
    public AudioSource audioSource;
    
    public static GlobalObjects Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GlobalObjects>();
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject("GlobalObjects");
                    _instance = singletonObject.AddComponent<GlobalObjects>();
                }
            }
            return _instance;
        }
    }


    // Para objetos en todas las escenas

    // private void Awake()
    // {
    //     if (_instance == null)
    //     {
    //         _instance = this;
    //         DontDestroyOnLoad(gameObject);
            
    //         foreach (GameObject obj in objectsToStore)
    //         {
    //             DontDestroyOnLoad(obj);
    //         }
    //     }
    //     else
    //     {
    //         Destroy(gameObject);
    //     }
    // }
    public void DoSomething()
    {
        Debug.Log("GlobalObjects is doing something!");
    }
}
