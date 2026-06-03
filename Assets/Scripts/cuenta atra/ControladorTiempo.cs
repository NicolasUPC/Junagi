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
        Time.timeScale = 0f; // Congela el juego y el tiempo físico de Unity

        // DETIENE EL AUDIO: Pausa de forma global todos los sonidos de la escena
        AudioListener.pause = true;

        if (menuPausaUI != null)
            menuPausaUI.SetActive(true); // Muestra el menú de pausa

        Cursor.lockState = CursorLockMode.None; // Libera el ratón para poder hacer clic
        Cursor.visible = true;
    }

    public void Reanudar()
    {
        juegoPausado = false;
        Time.timeScale = 1f; // Devuelve el juego a su velocidad normal

        // REACTIVA EL AUDIO: Hace que todos los sonidos vuelvan a sonar desde donde se quedaron
        AudioListener.pause = false;

        if (menuPausaUI != null)
            menuPausaUI.SetActive(false); // Oculta el menú de pausa
    }

    public void VolverAEmpezar()
    {
        Time.timeScale = 1f; // Asegura que el juego no se quede congelado
        AudioListener.pause = false; // Asegura que el audio vuelva a activarse en la nueva partida

        // Carga de nuevo la escena actual desde cero
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SalirDelJuego()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit(); // Cierra el juego (en la versión final compilada)
    }
}
