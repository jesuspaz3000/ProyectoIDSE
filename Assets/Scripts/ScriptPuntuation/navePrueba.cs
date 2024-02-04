
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class navePrueba : MonoBehaviour
{
    public float fV = 5000.0f;
    public float fR = -200.0f;
    public float fH = 10000.0f;
    public float maxSpeedV = 100.0f;
    public float maxSpeedH = 200.0f;

    public float fallingSpeed = 100.0f;
    public float horizontalLimit = 40.0f;

    private bool rotationH = false;
    private bool rotationV = false;
    private Rigidbody rb;

    public GameObject limiteBreaker;
    public Transform mainCamera;

    //Disparos
    [Header("Showting")]
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate=0.25f;//tiempo entre disparos
    private float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (mainCamera == null)
        {
            mainCamera = Camera.main.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Propulsar();
        Rotacion();
        // Disparar();
        MoverLimite();
    }
    private void Propulsar()
    {
        float prop = Input.GetAxis("Vertical");
        if (prop > 0)
        {
            //Calcular la velocidad actual
            float currenSpeedV = rb.velocity.z;//limite de velocidad en vertical
            if(currenSpeedV < maxSpeedV)
            {
                rb.velocity = new Vector3(rb.velocity.x, 0 , prop * fV * Time.deltaTime);
            }
            //sonido
        }
        float clampedX = Mathf.Clamp(transform.position.x, -horizontalLimit, horizontalLimit);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
    private void Rotacion()
    {
        float movH = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(movH * fH * Time.deltaTime, 0, rb.velocity.z);
        if (movH>0 && rotationH==false)
        {
            transform.Rotate(new Vector3(0, 0, -35));
            rotationH = true;
        }
        else if (movH<0 && rotationV==false)
        {
            transform.Rotate(new Vector3(0, 0, 35));
            rotationV = true;
        }
        else if (movH==0 && (rotationH==true || rotationV==true))
        {
            if (rotationH == true) 
            {
                transform.Rotate(new Vector3(0, 0, 35));
                rotationH = false;
                rotationV = false;
            }
            else if (rotationV ==  true) 
            {
                transform.Rotate(new Vector3(0, 0, -35));
                rotationV = false;
                rotationH = false;
            }
        }
        float clampedHorizontalSpeed = Mathf.Clamp(rb.velocity.x, -maxSpeedH, maxSpeedH);
        rb.velocity = new Vector3(clampedHorizontalSpeed, rb.velocity.y, rb.velocity.z);
    }
    private void MoverLimite()
    {
        //Mover el campo de limite con la camara
        if (limiteBreaker != null)
        {
            limiteBreaker.transform.position = new Vector3(0, 1, mainCamera.position.z);
        }
    }

    // private void Disparar()
    // {
    //     if (Input.GetButton("Fire1") && Time.time>nextFire)
    //     {
    //         nextFire = Time.time + fireRate;
    //         GameObject nuevoDisparo = Instantiate(shot, shotSpawn.position, Quaternion.identity);
    //         // nuevoDisparo.GetComponent<Move>().SetNaveVelocity(rb.velocity);
    //     }
    // }
}


