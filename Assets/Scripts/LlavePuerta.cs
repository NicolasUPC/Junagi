using UnityEngine;

public class LlavePuerta : MonoBehaviour
{
    public GameObject puerta;
    public GameObject llave;

    private bool cercaDeLlave = false;
    private bool yaUsada = false;

    void Update()
    {
        if (cercaDeLlave && !yaUsada && Input.GetKeyDown(KeyCode.E))
        {
            puerta.SetActive(false);

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