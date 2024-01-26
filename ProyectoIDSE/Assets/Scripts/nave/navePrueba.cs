using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class navePrueba : MonoBehaviour
{
    public float fV = 10000.0f;
    public float fR = -200.0f;
    public float fH = 10000.0f;
    public float maxSpeedV = 20.0f;
    public float maxSpeedH = 10.0f;

    public float fallingSpeed = 100.0f;
    public float horizontalLimit = 20.0f;

    public Transform mainCamera;
    public float cameraLowerLimit = 12.0f;

    private bool rotationH = false;
    private bool rotationV = false;
    private Rigidbody rb;


    private bool isPropelling = false;
    private bool isTurnLeft = false;
    private bool isTurnRigth = false;

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
        MoverCamera();
    }

    private void manageInput()
    {
        isPropelling = Input.GetAxis("Vertical") > 0 ? true : false;
        // isTurnRigth = 
    }
    private void Propulsar()
    {
        float prop = Input.GetAxis("Vertical");
        if (prop > 0)
        {
            //Calcular la velocidad actual
            rb.useGravity = true;
            float currenSpeedV = rb.velocity.y;//limite de velocidad en vertical
            if(currenSpeedV < maxSpeedV)
            {
                rb.AddForce(new Vector3(0, prop * fV * Time.deltaTime, 0));
            }
            //sonido
        }else if (prop == 0)
        {
            rb.useGravity = false;
            rb.AddForce(new Vector3(0,-fallingSpeed * Time.deltaTime, 0));
            //sin sonido
        }
        else
        {
            rb.useGravity= true;
        }
        float clampedX = Mathf.Clamp(transform.position.x, -horizontalLimit, horizontalLimit);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
    private void Rotacion()
    {
        float movH = Input.GetAxis("Horizontal");
        float currenSpeedH = rb.velocity.x;
        // (currenSpeedH < maxSpeedH)//&& currenSpeedH > minSpeedH
        rb.AddForce(new Vector3(movH * fH * Time.deltaTime, 0, 0));
        if (movH>0 && rotationH==false)
        {
            transform.Rotate(new Vector3(0, -35, 0));
            rotationH = true;
        }
        else if (movH<0 && rotationV==false)
        {
            transform.Rotate(new Vector3(0, 35, 0));
            rotationV = true;
        }
        else if (movH==0 && (rotationH==true || rotationV==true))
        {
            if (rotationH == true) 
            {
                transform.Rotate(new Vector3(0, 35, 0));
                rotationH = false;
                rotationV = false;
            }
            else if (rotationV ==  true) 
            {
                transform.Rotate(new Vector3(0, -35, 0));
                rotationV = false;
                rotationH = false;
            }
        }
        float clampedHorizontalSpeed = Mathf.Clamp(rb.velocity.x, -maxSpeedH, maxSpeedH);
        rb.velocity = new Vector3(clampedHorizontalSpeed, rb.velocity.y, rb.velocity.z);
    }
    private void MoverCamera()
    {
        // float cameraTargetY = Mathf.Max(transform.position.y + (rb.velocity.y<-1 ? -12.0f : 12.0f),cameraLowerLimit);

        // //cambio sueve de camara cuando sube o baja
        // //float newCameraY = Mathf.SmoothDamp(mainCamera.position.y, cameraTargetY, ref velocityY, smoothTime);

        // Vector3 cameraTargetPosition = new Vector3(mainCamera.position.x,cameraTargetY,mainCamera.position.z);
        // mainCamera.position = Vector3.Lerp(mainCamera.position,cameraTargetPosition,Time.deltaTime*5f);
    }
}
