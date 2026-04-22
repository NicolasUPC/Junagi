using UnityEngine;

public class LlavePuerta : MonoBehaviour
{
    [Header("Configuración de la Puerta")]
    public Animator puertaAnim;    // Arrastra el objeto con el Animator
    public Collider colisionPuerta; // Arrastra el objeto que tiene el Box Collider

    [Header("Configuración de la Llave")]
    public GameObject llave;

    private bool cercaDeLlave = false;
    private bool yaUsada = false;

    void Update()
    {
        // Detectar si el jugador pulsa E, está cerca y no ha usado la llave aún
        if (cercaDeLlave && !yaUsada && Input.GetKeyDown(KeyCode.E))
        {
            AbrirPuerta();
        }
    }

    void AbrirPuerta()
    {
        yaUsada = true;

        // 1. Activar la animación
        if (puertaAnim != null)
        {
            puertaAnim.SetTrigger("Abrir");
        }

        // 2. DESACTIVAR EL COLLIDER (Para que el jugador pueda pasar)
        if (colisionPuerta != null)
        {
            colisionPuerta.enabled = false;
            Debug.Log("Collider de la puerta desactivado.");
        }

        // 3. Eliminar la llave visualmente
        if (llave != null)
        {
            Destroy(llave);
        }

        // Desactivar este script para ahorrar recursos
        this.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cercaDeLlave = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cercaDeLlave = false;
        }
    }
}
//antiguo codigo
/*using UnityEngine;
public class LlavePuerta : MonoBehaviour
{
    public GameObject puerta; public GameObject llave; private bool cercaDeLlave = false; public objectManager objectManager; void Update()
    {
        if (cercaDeLlave == true && Input.GetKeyDown(KeyCode.E))
        {
            puerta.SetActive(false); // desaparece la puerta
            llave.SetActive(false); 
            objectManager.llave1 = true; 
        } 
    } 
    void OnTriggerEnter(Collider other) 
    { 
        if (other.gameObject.CompareTag("Llave"))
        { cercaDeLlave = true; 
        } 
    } 
    void OnTriggerExit(Collider other) 
    { 
        if (other.gameObject.CompareTag("Llave")) 
        { 
            cercaDeLlave = false; 
        } 
    } 
}
*/