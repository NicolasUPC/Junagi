/*using UnityEngine;

public class extintor : MonoBehaviour
{
    private bool cerca = false;
    public objectManager objectManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }-

    // Update is called once per frame
    void Update()
    {
        if (cerca && Input.GetKeyDown(KeyCode.E))
        {
            objectManager.extintor = true;
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
}*/
using UnityEngine;

public class ExtintorRecogible : MonoBehaviour
{
    [Header("Inventario")]
    public Sprite imagenParaElInventario;

    [Header("Referencias")]
    public objectManager objectManager;

    private bool jugadorCerca = false;

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
        objectManager.extintor = true;

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