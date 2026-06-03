/*using UnityEngine;
using System.Collections;

public class puertaFinal : MonoBehaviour
{
    private bool cercaPuertaFinal = false;

    public objectManager objectManager;
    public Animator animator;
    public Animator animatorUI;

    [Header("Pantalla Victoria")]
    public CanvasGroup victoriaUI;
    public float velocidadFade = 1f;

    private bool activado = false;

    void Start()
    {
        if (victoriaUI != null)
        {
            victoriaUI.alpha = 0f;
            victoriaUI.gameObject.SetActive(false);
            victoriaUI.interactable = false;
            victoriaUI.blocksRaycasts = false;
        }
    }

    void Update()
    {
        if (!activado &&
            objectManager.llave9 &&
            cercaPuertaFinal &&
            Input.GetKeyDown(KeyCode.E))
        {
            activado = true;

            animator.SetTrigger("AbrirPuerta");
            animatorUI.SetTrigger("FondoBlanco");

            StartCoroutine(MostrarVictoria());
        }
    }

    IEnumerator MostrarVictoria()
    {
        // Espera a que termine el fondo blanco
        yield return new WaitForSeconds(2f);

        victoriaUI.gameObject.SetActive(true);

        while (victoriaUI.alpha < 1f)
        {
            victoriaUI.alpha += Time.deltaTime * velocidadFade;
            yield return null;
        }

        victoriaUI.alpha = 1f;
        victoriaUI.interactable = true;
        victoriaUI.blocksRaycasts = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            cercaPuertaFinal = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            cercaPuertaFinal = false;
    }
}*/
/*using UnityEngine;
using System.Collections;

public class puertaFinal : MonoBehaviour
{
    private bool cercaPuertaFinal = false;

    public objectManager objectManager;
    public Animator animator;
    public Animator animatorUI;

    [Header("Pantalla Victoria")]
    public CanvasGroup victoriaUI;
    public float velocidadFade = 1f;

    private bool activado = false;

    void Start()
    {
        // Ocultamos el fondo blanco de la animación al empezar para evitar interferencias
        if (animatorUI != null)
            animatorUI.gameObject.SetActive(false);

        if (victoriaUI != null)
        {
            victoriaUI.alpha = 0f;
            victoriaUI.gameObject.SetActive(false);
            victoriaUI.interactable = false;
            victoriaUI.blocksRaycasts = false;
        }
    }

    void Update()
    {
        if (!activado &&
            objectManager.llave9 &&
            cercaPuertaFinal &&
            Input.GetKeyDown(KeyCode.E))
        {
            activado = true;

            if (animator != null)
                animator.SetTrigger("AbrirPuerta");

            // Activamos el objeto de la animación blanca justo en el momento de ganar
            if (animatorUI != null)
            {
                animatorUI.gameObject.SetActive(true);
                animatorUI.SetTrigger("FondoBlanco");
            }

            StartCoroutine(MostrarVictoria());
        }
    }

    IEnumerator MostrarVictoria()
    {
        // Espera a que termine el fondo blanco
        yield return new WaitForSeconds(2f);

        if (victoriaUI != null)
        {
            victoriaUI.gameObject.SetActive(true);
            victoriaUI.alpha = 0f;

            // LIBERAR EL RATÓN: Esto asegura que el jugador pueda interactuar con el menú de victoria
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            while (victoriaUI.alpha < 1f)
            {
                // Usamos unscaledDeltaTime por si acaso detienes el tiempo del juego al ganar
                victoriaUI.alpha += Time.unscaledDeltaTime * velocidadFade;
                yield return null;
            }

            victoriaUI.alpha = 1f;
            victoriaUI.interactable = true;
            victoriaUI.blocksRaycasts = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            cercaPuertaFinal = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            cercaPuertaFinal = false;
    }
}
*/
/*using UnityEngine;
using System.Collections;

public class puertaFinal : MonoBehaviour
{
    private bool cercaPuertaFinal = false;

    public objectManager objectManager;
    public Animator animator;
    public Animator animatorUI;

    [Header("Pantalla Victoria")]
    public CanvasGroup victoriaUI;
    public float velocidadFade = 1f;

    private bool activado = false;

    void Start()
    {
        // Aseguramos que la UI de victoria empiece totalmente invisible e interactuable desactivada
        if (victoriaUI != null)
        {
            victoriaUI.alpha = 0f;
            victoriaUI.gameObject.SetActive(false);
            victoriaUI.interactable = false;
            victoriaUI.blocksRaycasts = false;
        }
    }

    void Update()
    {
        if (!activado &&
            objectManager.llave9 &&
            cercaPuertaFinal &&
            Input.GetKeyDown(KeyCode.E))
        {
            activado = true;

            if (animator != null)
                animator.SetTrigger("AbrirPuerta");

            // Activamos el contenedor para que la animación empiece a verse
            if (victoriaUI != null)
            {
                victoriaUI.gameObject.SetActive(true);
            }

            if (animatorUI != null)
            {
                animatorUI.SetTrigger("FondoBlanco");
            }

            StartCoroutine(MostrarVictoria());
        }
    }

    IEnumerator MostrarVictoria()
    {
        // Esperamos 2 segundos a que el fondo blanco cubra la pantalla
        yield return new WaitForSeconds(2f);

        // Liberamos el ratón inmediatamente para interactuar
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Hacemos el fundido (Fade In) del Canvas entero para que aparezcan las letras y botones
        while (victoriaUI.alpha < 1f)
        {
            victoriaUI.alpha += Time.unscaledDeltaTime * velocidadFade;
            yield return null;
        }

        victoriaUI.alpha = 1f;
        victoriaUI.interactable = true;   // Activa los clics en los botones
        victoriaUI.blocksRaycasts = true; // Permite al ratón detectar la UI
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            cercaPuertaFinal = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            cercaPuertaFinal = false;
    }
}*/
using UnityEngine;

public class puertaFinal : MonoBehaviour
{
    private bool cercaPuertaFinal = false;
    private bool activado = false;

    public objectManager objectManager; // Tu script que comprueba las llaves
    public Animator animator;           // El Animator de la puerta física

    void Update()
    {
        // Si no se ha abierto, tienes la llave 9, estás cerca y pulsas la E...
        if (!activado &&
            objectManager != null &&
            objectManager.llave9 &&
            cercaPuertaFinal &&
            Input.GetKeyDown(KeyCode.E))
        {
            activado = true;

            // Abrimos la puerta física de forma independiente
            if (animator != null)
            {
                animator.SetTrigger("AbrirPuerta");
            }

            Debug.Log("¡Puerta abierta con éxito con la Llave 9!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            cercaPuertaFinal = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            cercaPuertaFinal = false;
    }
}

