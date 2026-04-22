using UnityEngine;

public class LlavePuerta : MonoBehaviour
{
    public Animator puertaAnim; // Arrastra aquí el componente Animator de la puerta
    public GameObject llave;

    private bool cercaDeLlave = false;
    private bool yaUsada = false;

    void Update()
    {
        // Si presionas E, estás cerca y no se ha usado...
        if (cercaDeLlave && !yaUsada && Input.GetKeyDown(KeyCode.E))
        {
            // ACTIVAR ANIMACIÓN
            if (puertaAnim != null)
            {
                puertaAnim.SetTrigger("Abrir"); // Dispara el trigger que creamos
            }

            // Eliminar la llave
            Destroy(llave);

            yaUsada = true;
            this.enabled = false;
        }
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