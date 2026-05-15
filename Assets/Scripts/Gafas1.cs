using UnityEngine;
using TMPro;
using System.Collections;

public class Gafas1 : MonoBehaviour
{
    private bool cerca = false;
    public static bool tieneGafas = false;

    [Header("Configuración Inventario")]
    public Sprite iconoGafas; // Arrastra aquí la imagen de las gafas en el Inspector
    private InventarioManager inventario;

    [Header("Configuración UI Mensaje")]
    public TextMeshProUGUI mensajeUI;
    public float tiempoVisible = 2f;
    public float tiempoFade = 2f;

    void Start()
    {
        // IMPORTANTE: Si el objeto empieza desactivado, este Start no se ejecutará.
        // Asegúrate de que el objeto esté activo en la jerarquía.

        mensajeUI.gameObject.SetActive(false);

        // Buscamos el gestor del inventario
        inventario = FindObjectOfType<InventarioManager>();
    }

    void Update()
    {
        if (cerca && Input.GetKeyDown(KeyCode.E))
        {
            RecogerGafas();
        }
    }

    void RecogerGafas()
    {
        tieneGafas = true;

        // 1. Añadimos al inventario visual
        if (inventario != null)
        {
            inventario.AñadirObjetoAlInventario(iconoGafas);
        }

        // 2. Iniciamos el mensaje
        StartCoroutine(MostrarMensaje());

        // 3. CAMBIO IMPORTANTE: 
        // En lugar de Destroy(gameObject) aquí, desactivamos el modelo visual y el collider
        // para que la corrutina pueda seguir funcionando hasta que el texto desaparezca.
        GetComponent<Collider>().enabled = false;
        if (transform.Find("Visual") != null) // Si tienes el modelo dentro de un hijo
            transform.Find("Visual").gameObject.SetActive(false);
        else
            GetComponent<MeshRenderer>().enabled = false; // Si el modelo es el mismo objeto
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

        mensajeUI.gameObject.SetActive(false); // Desactivar en lugar de destruir si quieres reutilizarlo

        // Ahora que todo terminó, destruimos el objeto de las gafas del mundo
        Destroy(gameObject);
    }
}