using UnityEngine;
using TMPro;
using System.Collections;

public class Gafas : MonoBehaviour
{
    private bool cerca = false;

    public static bool tieneGafas = false;

    public TextMeshProUGUI mensajeUI;

    public float tiempoVisible = 2f;
    public float tiempoFade = 2f;

    void Start()
    {
        gameObject.SetActive(false);
        mensajeUI.gameObject.SetActive(false);
    }

    void Update()
    {
        if (cerca && Input.GetKeyDown(KeyCode.E))
        {
            tieneGafas = true;

            StartCoroutine(MostrarMensaje());

            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            cerca = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            cerca = false;
    }

    IEnumerator MostrarMensaje()
    {
        mensajeUI.gameObject.SetActive(true);

        Color color = mensajeUI.color;
        color.a = 1f;
        mensajeUI.color = color;

        yield return new WaitForSeconds(tiempoVisible);

        float t = 0f;

        while (t < tiempoFade)
        {
            t += Time.deltaTime;

            float alpha = Mathf.Lerp(1f, 0f, t / tiempoFade);

            Color c = mensajeUI.color;
            c.a = alpha;
            mensajeUI.color = c;

            yield return null;
        }

        mensajeUI.color = new Color(
            mensajeUI.color.r,
            mensajeUI.color.g,
            mensajeUI.color.b,
            0f
        );

        Destroy(mensajeUI.gameObject); 
    }
}