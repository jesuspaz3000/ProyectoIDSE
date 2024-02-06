using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthBall : MonoBehaviour
{
    public int HealthMount = 2;
    public AudioClip soundCollect;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        print("HealthBall");
        if(other.CompareTag("Player"))
        {
            CollectBall();
        }
        else
        {
            print(other.tag);
            return;
        }
    }
    void CollectBall(){
        
        print("HealthBall Collected ");
        GlobalObjects.Instance.gameController.IncreaseVida(HealthMount);
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(soundCollect, transform.position);
    }
}
