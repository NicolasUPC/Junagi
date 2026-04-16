using UnityEngine;

public class LlavePuerta : MonoBehaviour
{
    public GameObject puerta;
    public GameObject llave;
    private bool cercaDeLlave = false;
    public objectManager objectManager;

    void Update()
    {
        if (cercaDeLlave && Input.GetKeyDown(KeyCode.E))
        {
            puerta.SetActive(false); // desaparece la puerta
            llave.SetActive(false);
            objectManager.llave1 = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Llave"))
        {
            cercaDeLlave = true;
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