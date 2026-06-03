using UnityEngine;
using TMPro;

public class ControladorCajaFuerte : MonoBehaviour
{
    [Header("Configuración Secreta")]
    public string contrasenaCorrecta = "1925";

    [Header("Referencias UI")]
    public GameObject menuCajaFuerteUI; // El objeto raíz de la UI
    public TMP_InputField campoTexto;   // El cuadro donde se escribe la contraseña

    [Header("Animación de la Caja Fuerte")]
    public Animator cajaFuerteAnim;     // El Animator de la caja fuerte física

    [Header("Recompensa Inside")]
    public GameObject objetoRecompensa; // Arrastra aquí la llave que aparecerá dentro

    private bool jugadorCerca = false;
    private bool estaAbierta = false;
    private bool menuActivo = false;

    void Start()
    {
        if (menuCajaFuerteUI != null)
            menuCajaFuerteUI.SetActive(false); // Asegura que empiece oculto

        if (objetoRecompensa != null)
            objetoRecompensa.SetActive(false); // Esconde la llave al iniciar el juego
    }

    void Update()
    {
        // INTERACCIÓN PRINCIPAL: Si está cerca, cerrada y pulsa la E, abre el menú
        if (jugadorCerca && !estaAbierta && !menuActivo && Input.GetKeyDown(KeyCode.E))
        {
            AbrirMenuUI();
        }
        // ACCESOS RÁPIDOS CUANDO EL MENÚ YA ESTÁ ABIERTO:
        else if (menuActivo)
        {
            // Si presiona Enter o el Intro del teclado numérico, comprueba la contraseña
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                ComprobarContrasena();
            }

            // Si presiona Escape, cierra la interfaz y vuelve a caminar
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                CerrarMenuUI();
            }
        }
    }

    void AbrirMenuUI()
    {
        menuActivo = true;
        menuCajaFuerteUI.SetActive(true);
        campoTexto.text = ""; // Limpia cualquier intento previo
        campoTexto.ActivateInputField(); // Pone el cursor listo para escribir

        // Congela el movimiento/tiempo del juego y libera el puntero del ratón
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CerrarMenuUI()
    {
        menuActivo = false;
        menuCajaFuerteUI.SetActive(false);

        // Devuelve el juego a la velocidad normal para volver a caminar
        Time.timeScale = 1f;
    }

    // Se ejecuta al pulsar el botón Aceptar o presionar Enter
    public void ComprobarContrasena()
    {
        if (campoTexto != null && campoTexto.text == contrasenaCorrecta)
        {
            Debug.Log("¡Contraseña Correcta!");
            estaAbierta = true;

            // Activa la transición a la animación (Trigger "Abrir")
            if (cajaFuerteAnim != null)
            {
                cajaFuerteAnim.SetTrigger("Abrir");
            }

            // HACE APARECER LA LLAVE: Activa el objeto dentro de la caja
            if (objetoRecompensa != null)
            {
                objetoRecompensa.SetActive(true);
                Debug.Log("La llave ha aparecido dentro de la caja fuerte.");
            }

            CerrarMenuUI();
        }
        else
        {
            Debug.Log("Contraseña Incorrecta. Inténtalo de nuevo.");
            if (campoTexto != null)
            {
                campoTexto.text = ""; // Borra el texto erróneo automáticamente
                campoTexto.ActivateInputField(); // Vuelve a enfocar el cuadro de texto
            }
        }
    }

    // Detecta si el jugador entra al área de la caja fuerte
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
        }
    }

    // Detecta si el jugador se aleja de la caja fuerte
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;
            if (menuActivo)
            {
                CerrarMenuUI(); // Cierra por seguridad si el jugador se aleja
            }
        }
    }
}
