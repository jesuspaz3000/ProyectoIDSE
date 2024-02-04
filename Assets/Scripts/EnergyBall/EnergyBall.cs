using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnergyBall : MonoBehaviour
{
    public int energyMount = 2;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        print("EnergyBall");
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
        print("EnergyBall Collected ");
        GlobalObjects.Instance.gameController.IncreaseEnergy(energyMount);
        Destroy(gameObject);
    }
}
