using UnityEngine;

public class CajaMinijuego : MonoBehaviour
{
    [Header("Animación de esta Caja")]
    public Animator cajaAnimator;         // El Animator de esta caja específica

    [Header("Luz asociada en la pared")]
    public Renderer mallaLuz;            // El objeto 3D de su luz en la pared
    public Light luzPuntual;              // Su componente Point Light de la pared
    public Material materialVerde;        // Arrastra aquí el material 'luzVerde'

    [Header("Recompensa")]
    public GameObject objetoInterior;     // El objeto que aparecerá dentro de la caja

    private GestorMinijuego gestor;
    private bool habitacionActivada = false;
    private bool cercaDeCaja = false;
    private bool yaInteractuada = false;

    void Start()
    {
        // Buscamos automáticamente el gestor central en la escena
        gestor = Object.FindFirstObjectByType<GestorMinijuego>();

        // El objeto de recompensa empieza oculto dentro de la caja
        if (objetoInterior != null)
        {
            objetoInterior.SetActive(false);
        }
    }

    // Llamado por el Trigger de la entrada de la habitación
    public void EntrarEnHabitacion()
    {
        if (!habitacionActivada)
        {
            habitacionActivada = true;
            if (cajaAnimator != null)
            {
                cajaAnimator.SetTrigger("Abrir"); // Transición a la animación de abrir caja
            }
        }
    }

    void Update()
    {
        // Si el jugador está cerca, la habitación está activa, pulsa E y no se ha usado antes
        if (habitacionActivada && cercaDeCaja && !yaInteractuada && Input.GetKeyDown(KeyCode.E))
        {
            InteractuarConCaja();
        }
    }

    void InteractuarConCaja()
    {
        yaInteractuada = true;

        // Mostrar el objeto dentro de la caja (y se queda abierta)
        if (objetoInterior != null)
        {
            objetoInterior.SetActive(true);
        }

        // Cambiar material de su luz a verde
        if (mallaLuz != null && materialVerde != null)
        {
            mallaLuz.material = materialVerde;
        }

        // Cambiar el Tag de su Point Light a "Verde"
        if (luzPuntual != null)
        {
            luzPuntual.gameObject.tag = "Verde";
        }

        // Avisar al gestor central que sume una caja
        if (gestor != null)
        {
            gestor.RegistrarCajaCompletada();
        }
    }

    // Detectar si el jugador está frente a la caja
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cercaDeCaja = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cercaDeCaja = false;
        }
    }
}
