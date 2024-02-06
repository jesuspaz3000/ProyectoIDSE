using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class RutinaEnemigo2 : MonoBehaviour
{
    [SerializeField] private float velodidadMovimiento = 20;
    [SerializeField] private float rangoY = 10f;
    [SerializeField] private float rangoX = 60f;

    [SerializeField] private float distaniaMinima;

    public float rotationVelocity = 5;

    public Vector3 offset = new Vector3(0,20,0);
    private Vector3 nuevaPosicion;
    private float timeToChangePosition = 2;
    private float timeOfLastPosition = 0;
    private Rigidbody rb;
    void Start()
    {
        timeOfLastPosition += Time.deltaTime;
        if (timeOfLastPosition >= timeToChangePosition){
            InicializarNuevaPosicionYDistanciaMinima();
            timeOfLastPosition = 0;
        }
        rb = GetComponent<Rigidbody>();
        rb.maxLinearVelocity = 60f;
    }
    // Update is called once per frame
    void Update()
    {
        // if (Vector3.Distance(transform.position, nuevaPosicion) < distaniaMinima)
        // {
        //     InicializarNuevaPosicionYDistanciaMinima();
        // }
        // transform.position = Vector3.MoveTowards(transform.position, nuevaPosicion, velodidadMovimiento * Time.deltaTime);

        Vector3 direccion = GlobalObjects.Instance.NavePrincipal.transform.position - transform.position;
        Quaternion nuevaRotacion = Quaternion.LookRotation(direccion);

        transform.rotation = Quaternion.Slerp(transform.rotation, nuevaRotacion, rotationVelocity*Time.deltaTime);



        Vector3 DireccionMov = (GlobalObjects.Instance.NavePrincipal.transform.position + offset) - transform.position;

        rb.AddForce(DireccionMov*velodidadMovimiento*Time.deltaTime);
        

    }   
    void InicializarNuevaPosicionYDistanciaMinima()
    {
        float nuevaPosicionX = Random.Range(-rangoX / 2f, rangoX / 2f);
        float nuevaPosicionY = Random.Range(-rangoY / 2f, rangoY / 2f);
        nuevaPosicion = new Vector3(nuevaPosicionX, nuevaPosicionY + 50, transform.position.z) + GlobalObjects.Instance.NavePrincipal.transform.position;

        distaniaMinima = Random.Range(1f, 5f);


    }
}
