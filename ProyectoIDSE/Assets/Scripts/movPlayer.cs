using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nave : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 200.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Mover la nave hacia adelante y hacia atr�s
        float movimiento = Input.GetAxis("Vertical") * velocidadMovimiento * Time.deltaTime;
        transform.Translate(0, 0, movimiento);

        // Girar la nave a la izquierda y derecha
        float rotacion = Input.GetAxis("Horizontal") * velocidadRotacion * Time.deltaTime;
        transform.Rotate(0, rotacion, 0);
    }
}
