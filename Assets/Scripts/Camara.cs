using UnityEngine;

public class Camara : MonoBehaviour
{
    public GameObject jugador;   // personaje que rota en horizontal
    public float speed = 100f;   // sensibilidad del ratón
    private float giroX = 0f;    // rotación vertical de la cámara
    public GameObject empty;     // objeto que mueve la cámara arriba/abajo

    void Start()
    {
        // bloquea el cursor en el centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // movimiento del ratón
        float x = Input.GetAxis("Mouse X") * speed * Time.deltaTime;
        float y = Input.GetAxis("Mouse Y") * speed * Time.deltaTime;

        // ROTACIÓN VERTICAL (arriba y abajo)
        giroX += y;  // antes era -= y (eso invertía el movimiento)

        // limitamos la rotación para que no gire completamente
        giroX = Mathf.Clamp(giroX, -90f, 90f);

        // rotamos el objeto que controla la inclinación de la cámara
        empty.transform.localRotation = Quaternion.Euler(giroX, 0, 0);

        // ROTACIÓN HORIZONTAL (izquierda y derecha)
        jugador.transform.Rotate(Vector3.up * x);
    }
}