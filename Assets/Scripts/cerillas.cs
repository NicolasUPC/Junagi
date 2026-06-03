using UnityEngine;

public class CerillasRecogibles : MonoBehaviour
{
    [Header("Inventario")]
    public Sprite imagenParaElInventario;

    [Header("Referencias")]
    public objectManager objectManager;

    private bool jugadorCerca = false;

    void Start()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (jugadorCerca && Input.GetKeyDown(KeyCode.E))
        {
            Interactuar();
        }
    }

    void Interactuar()
    {
        // Añadir al inventario
        InventarioManager.Instancia.AñadirObjeto(imagenParaElInventario);

        // Activar variable del manager
        objectManager.cerilla = true;

        // Destruir objeto
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;
        }
    }
}