using UnityEngine;
using System.Collections;

public class TriggerVictoria : MonoBehaviour
{
    [Header("Animación Fondo Blanco")]
    public Animator animatorUI; // Objeto de UI que hace el parpadeo blanco

    [Header("Pantalla Victoria")]
    public CanvasGroup victoriaUI; // El objeto "Victoria" con el CanvasGroup y los botones
    public float velocidadFade = 1f;

    private bool victoriaActivada = false;

    void Start()
    {
        // Desactivamos el fondo blanco al iniciar la partida para que no tape nada
        if (animatorUI != null)
            animatorUI.gameObject.SetActive(false);

        // Ocultamos por completo el cartel y los botones de victoria
        if (victoriaUI != null)
        {
            victoriaUI.alpha = 0f;
            victoriaUI.gameObject.SetActive(false);
            victoriaUI.interactable = false;
            victoriaUI.blocksRaycasts = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Si el jugador cruza el umbral y la victoria aún no ha saltado.
        if (!victoriaActivada && other.CompareTag("Player"))
        {
            victoriaActivada = true;

            // Encendemos el fondo blanco y lanzamos su animación
            if (animatorUI != null)
            {
                animatorUI.gameObject.SetActive(true);
                animatorUI.SetTrigger("FondoBlanco");
            }

            // Iniciamos la secuencia temporal para los botones
            StartCoroutine(SecuenciaVictoria());
        }
    }

    IEnumerator SecuenciaVictoria()
    {
        // Esperamos 2 segundos exactos a que el fondo blanco cubra la pantalla
        yield return new WaitForSeconds(2f);

        if (victoriaUI != null)
        {
            // Activamos el contenedor de los botones
            victoriaUI.gameObject.SetActive(true);
            victoriaUI.alpha = 0f;

            
            
            victoriaUI.transform.SetAsLastSibling();

            // LIBERAMOS EL RATÓN al mismo tiempo para que puedas hacer clic
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // Aparecen suavemente las letras y los botones encima del fondo blanco
            while (victoriaUI.alpha < 1f)
            {
                victoriaUI.alpha += Time.unscaledDeltaTime * velocidadFade;
                yield return null;
            }

            victoriaUI.alpha = 1f;
            victoriaUI.interactable = true;   // Activa los botones
            victoriaUI.blocksRaycasts = true; // Permite al ratón colisionar con la UI
        }
    }
}

