using UnityEngine;
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
}