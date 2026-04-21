using UnityEngine;
using TMPro;

public class MensajeInicio : MonoBehaviour
{
    public TextMeshProUGUI textoMensaje;

    void Start()
    {
        textoMensaje.gameObject.SetActive(true);
        StartCoroutine(FadeOut());
    }

    System.Collections.IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(8f);

        float tiempo = 2f;
        float t = 0f;

        Color colorOriginal = textoMensaje.color;

        while (t < tiempo)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, t / tiempo);

            textoMensaje.color = new Color(
                colorOriginal.r,
                colorOriginal.g,
                colorOriginal.b,
                alpha
            );

            yield return null;
        }

        textoMensaje.gameObject.SetActive(false);
    }
}