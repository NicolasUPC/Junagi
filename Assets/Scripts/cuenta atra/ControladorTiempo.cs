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

        // Desactivamos el objeto del fondo al empezar para que no bloquee los clics
        if (animatorUI != null)
            animatorUI.gameObject.SetActive(false);

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

        // Activamos el objeto del fondo justo cuando se agota el tiempo
        if (animatorUI != null)
        {
            animatorUI.gameObject.SetActive(true);
            animatorUI.SetTrigger("FondoNegro");
        }

        StartCoroutine(MostrarDerrotaConRetraso());
    }

    IEnumerator MostrarDerrotaConRetraso()
    {
        yield return new WaitForSeconds(2f); // Ajusta a la duración de tu animación

        derrotaUI.gameObject.SetActive(true);
        derrotaUI.alpha = 0f;

        // LIBERAR EL CURSOR DEL RATÓN
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        while (derrotaUI.alpha < 1f)
        {
            derrotaUI.alpha += Time.unscaledDeltaTime * velocidadFade;
            yield return null;
        }

        derrotaUI.alpha = 1f;
        derrotaUI.interactable = true;   // Activa la interacción con los botones
        derrotaUI.blocksRaycasts = true; // Permite que el mouse detecte el Canvas de derrota
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

        // LIBERAR EL CURSOR DEL RATÓN
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

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
