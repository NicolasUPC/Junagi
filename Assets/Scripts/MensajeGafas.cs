using UnityEngine;
using TMPro;
using System.Collections;

public class TextoTMPAutoDestroy : MonoBehaviour
{
    public TextMeshProUGUI textoTMP;

    public void MostrarTexto(string mensaje)
    {
        textoTMP.text = mensaje;

        StartCoroutine(Destruir());
    }

    IEnumerator Destruir()
    {
        yield return new WaitForSeconds(2f);

        Destroy(textoTMP.gameObject);
        Destroy(gameObject); 
    }
}