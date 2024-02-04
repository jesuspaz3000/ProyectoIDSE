using UnityEngine;

public class MovimientoNave : MonoBehaviour
{
    public float fuerzaX = 500; // Fuerza en el eje X
    public float fuerzaY = 500; // Fuerza en el eje Y

    public float velocidadMaximaX = 40f; // Velocidad máxima en el eje X
    public float velocidadMaximaY = 40f; // Velocidad máxima en el eje Y

    public float frenadoRapido = 2f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // rb.velocity
    }

    void Update()
    {
        // Obtener la entrada del usuario en los ejes horizontal y vertical
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        // Calcular la dirección del movimiento
        Vector3 movimiento = new Vector3(movimientoHorizontal, movimientoVertical, 0f);

        // Normalizar el vector para que el movimiento diagonal no sea más rápido
        // movimiento.Normalize();

        // Calcular la velocidad actual en los ejes X e Y
        float velocidadActualX = rb.velocity.x;
        float velocidadActualY = rb.velocity.y;

        // Calcular la fuerza que se aplicará
        float fuerzaAplicadaX = (movimiento.x * fuerzaX) * Time.deltaTime;
        float fuerzaAplicadaY = (movimiento.y * fuerzaY) * Time.deltaTime;

        float fuerzaAplicar_x = 0;
        float fuerzaAplicar_y = 0;
        // Aplicar fuerzas en los ejes X e Y hasta alcanzar la velocidad máxima
        if (Mathf.Abs(velocidadActualX) < velocidadMaximaX)
        {
            fuerzaAplicar_x = fuerzaAplicadaX;
        }
        else if (velocidadActualX >= velocidadMaximaX)
        {
            if (fuerzaAplicadaX < 0)
            {
                fuerzaAplicar_x = fuerzaAplicadaX;
            }
        }
        else if (velocidadActualX <= velocidadMaximaX)
        {
            if (fuerzaAplicadaX > 0)
            {
                fuerzaAplicar_x = fuerzaAplicadaX;
            }
        }

        if (Mathf.Abs(velocidadActualY) < velocidadMaximaY ||
            velocidadActualY >= velocidadMaximaY && fuerzaAplicadaY < 0 ||
            velocidadActualY <= velocidadMaximaY && fuerzaAplicadaY > 0
            )
        {
            fuerzaAplicar_y = fuerzaAplicadaY;
        }
        if (GlobalObjects.Instance.gameController.energia > 0)
            rb.AddForce(new Vector3(fuerzaAplicar_x, fuerzaAplicar_y, 0), ForceMode.VelocityChange);
        // rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);

        if (movimiento == Vector3.zero)
        {
            rb.velocity = new Vector3(
                Mathf.Lerp(rb.velocity.x * 0.6f, 0f, Time.deltaTime * frenadoRapido),
                Mathf.Lerp(rb.velocity.y * 0.6f, 0f, Time.deltaTime * frenadoRapido),
                0f
            );
        }
        else
        {
            GlobalObjects.Instance.gameController.DecreaseEnergy(movimiento.magnitude * Time.deltaTime);
        }
    }


}
