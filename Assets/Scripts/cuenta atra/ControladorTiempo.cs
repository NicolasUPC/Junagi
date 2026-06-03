/*using UnityEngine;
using TMPro;

public class ControladorTiempo : MonoBehaviour
{
    [Header("Configuración")]
    public float tiempoInicial = 630f; // Tiempo en segundos (Ej: 630 segundos son 10:30)

    [Header("Referencias UI")]
    public TextMeshProUGUI textoUI; // Arrastra aquí el texto de la pantalla

    private float tiempoRestante;
    private bool cuentaActiva = false;

    void Start()
    {
        tiempoRestante = tiempoInicial;
        if (textoUI != null)
        {
            textoUI.gameObject.SetActive(false); // Oculta el texto al iniciar
        }
    }

    void Update()
    {
        if (cuentaActiva)
        {
            if (tiempoRestante > 0)
            {
                tiempoRestante -= Time.deltaTime;
                ActualizarTexto(tiempoRestante);
            }
            else
            {
                tiempoRestante = 0;
                cuentaActiva = false;
                FinalizarCuenta();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Activa la cuenta atrás cuando el jugador entra en el trigger
        if (!cuentaActiva && tiempoRestante == tiempoInicial)
        {
            cuentaActiva = true;
            if (textoUI != null)
            {
                textoUI.gameObject.SetActive(true); // Muestra el texto
            }
        }
    }

    void ActualizarTexto(float tiempo)
    {
        if (textoUI != null)
        {
            // Calculamos los minutos enteros dividiendo el tiempo entre 60
            int minutos = Mathf.FloorToInt(tiempo / 60);

            // Calculamos los segundos restantes usando el residuo de la división
            int segundos = Mathf.FloorToInt(tiempo % 60);

            // Ajustamos el texto para que siempre tenga dos dígitos (ej: "05" en vez de "5")
            textoUI.text = string.Format("{0:00}:{1:00}", minutos, segundos);
        }
    }

    void FinalizarCuenta()
    {
        if (textoUI != null)
        {
            textoUI.text = "00:00"; // Deja el marcador en cero al terminar
        }
        Debug.Log("La cuenta atrás ha terminado.");
    }
}
*/
/*using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Necesario para reiniciar la escena

public class ControladorTiempo : MonoBehaviour
{
    [Header("Configuración")]
    public float tiempoInicial = 630f; // Tiempo en segundos (630s = 10:30)

    [Header("Referencias UI")]
    public TextMeshProUGUI textoUI;    // Texto del cronómetro
    public GameObject menuPausaUI;    // El panel de fondo de la pausa

    private float tiempoRestante;
    private bool cuentaActiva = false;
    private bool juegoPausado = false;

    void Start()
    {
        tiempoRestante = tiempoInicial;

        if (textoUI != null)
            textoUI.gameObject.SetActive(false); // Oculta el cronómetro al inicio

        if (menuPausaUI != null)
            menuPausaUI.SetActive(false);        // Asegura que la pausa esté oculta al iniciar
    }

    void Update()
    {
        // Detecta si pulsas la tecla Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                Reanudar();
            }
            else
            {
                Pausar();
            }
        }

        // Control del cronómetro
        if (cuentaActiva && !juegoPausado)
        {
            if (tiempoRestante > 0)
            {
                tiempoRestante -= Time.deltaTime;
                ActualizarTexto(tiempoRestante);
            }
            else
            {
                tiempoRestante = 0;
                cuentaActiva = false;
                FinalizarCuenta();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!cuentaActiva && tiempoRestante == tiempoInicial)
        {
            cuentaActiva = true;
            if (textoUI != null)
                textoUI.gameObject.SetActive(true);
        }
    }

    void ActualizarTexto(float tiempo)
    {
        if (textoUI != null)
        {
            int minutos = Mathf.FloorToInt(tiempo / 60);
            int segundos = Mathf.FloorToInt(tiempo % 60);
            textoUI.text = string.Format("{0:00}:{1:00}", minutos, segundos);
        }
    }

    void FinalizarCuenta()
    {
        if (textoUI != null)
            textoUI.text = "00:00";
        Debug.Log("La cuenta atrás ha terminado.");
    }

    // ==========================================
    // FUNCIONES PARA LOS BOTONES Y LA PAUSA
    // ==========================================

    public void Pausar()
    {
        juegoPausado = true;
        Time.timeScale = 0f; // Congela por completo el juego y el tiempo físico de Unity

        if (menuPausaUI != null)
            menuPausaUI.SetActive(true); // Muestra el menú de pausa

        Cursor.lockState = CursorLockMode.None; // Libera el ratón para poder hacer clic
        Cursor.visible = true;
    }

    public void Reanudar()
    {
        juegoPausado = false;
        Time.timeScale = 1f; // Devuelve el juego a su velocidad normal

        if (menuPausaUI != null)
            menuPausaUI.SetActive(false); // Oculta el menú de pausa

        // Si tu juego bloquea el ratón en primera persona, descomenta la línea de abajo borrando las barras:
        // Cursor.lockState = CursorLockMode.Locked; Cursor.visible = false;
    }

    public void VolverAEmpezar()
    {
        Time.timeScale = 1f; // Asegura que el juego no se quede congelado al reiniciar
        // Carga de nuevo la escena actual desde cero (reinicia posiciones y tiempo)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SalirDelJuego()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit(); // Cierra el juego (solo funciona en el juego ya exportado .exe/.app)
    }
}
*/
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class ControladorTiempo : MonoBehaviour
{
    [Header("Configuración")]
    public float tiempoInicial = 600f;

    [Header("Referencias UI")]
    public TextMeshProUGUI textoUI;
    public GameObject menuPausaUI;

    [Header("Animación Fondo Negro")]
    public Animator animatorUI;

    [Header("Pantalla Derrota")]
    public CanvasGroup derrotaUI;
    public float velocidadFade = 1f; // Menor = más lento

    private float tiempoRestante;
    private bool cuentaActiva = false;
    private bool juegoPausado = false;

    void Start()
    {
        tiempoRestante = tiempoInicial;

        if (textoUI != null)
            textoUI.gameObject.SetActive(false);

        if (menuPausaUI != null)
            menuPausaUI.SetActive(false);

        if (derrotaUI != null)
        {
            derrotaUI.alpha = 0f;
            derrotaUI.gameObject.SetActive(false);
            derrotaUI.interactable = false;
            derrotaUI.blocksRaycasts = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                Reanudar();
            }
            else
            {
                Pausar();
            }
        }

        if (cuentaActiva && !juegoPausado)
        {
            if (tiempoRestante > 0)
            {
                tiempoRestante -= Time.deltaTime;
                ActualizarTexto(tiempoRestante);
            }
            else
            {
                tiempoRestante = 0;
                cuentaActiva = false;
                FinalizarCuenta();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!cuentaActiva && tiempoRestante == tiempoInicial)
        {
            cuentaActiva = true;

            if (textoUI != null)
                textoUI.gameObject.SetActive(true);
        }
    }

    void ActualizarTexto(float tiempo)
    {
        if (textoUI != null)
        {
            int minutos = Mathf.FloorToInt(tiempo / 60);
            int segundos = Mathf.FloorToInt(tiempo % 60);
            textoUI.text = string.Format("{0:00}:{1:00}", minutos, segundos);
        }
    }

    void FinalizarCuenta()
    {
        if (textoUI != null)
            textoUI.text = "00:00";

        Debug.Log("La cuenta atrás ha terminado.");

        // Activa la animación del fondo negro
        animatorUI.SetTrigger("FondoNegro");
        StartCoroutine(MostrarDerrotaConRetraso());

    }
    IEnumerator MostrarDerrotaConRetraso()
    {
        yield return new WaitForSeconds(2f); // Ajusta a la duración de tu animación

        derrotaUI.gameObject.SetActive(true);

        derrotaUI.alpha = 0f;

        while (derrotaUI.alpha < 1f)
        {
            derrotaUI.alpha += Time.deltaTime;
            yield return null;
        }

        derrotaUI.alpha = 1f;
    }
    // Esta función será llamada desde el Animation Event
    public void MostrarDerrota()
    {
        StartCoroutine(FadeInDerrota());
    }

    IEnumerator FadeInDerrota()
    {
        derrotaUI.gameObject.SetActive(true);

        derrotaUI.alpha = 0f;
        derrotaUI.interactable = false;
        derrotaUI.blocksRaycasts = false;

        while (derrotaUI.alpha < 1f)
        {
            derrotaUI.alpha += Time.unscaledDeltaTime * velocidadFade;
            yield return null;
        }

        derrotaUI.alpha = 1f;
        derrotaUI.interactable = true;
        derrotaUI.blocksRaycasts = true;
    }

    // ==========================================
    // PAUSA
    // ==========================================

    public void Pausar()
    {
        juegoPausado = true;
        Time.timeScale = 0f;

        AudioListener.pause = true;

        if (menuPausaUI != null)
            menuPausaUI.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Reanudar()
    {
        juegoPausado = false;
        Time.timeScale = 1f;

        AudioListener.pause = false;

        if (menuPausaUI != null)
            menuPausaUI.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void VolverAEmpezar()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SalirDelJuego()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}