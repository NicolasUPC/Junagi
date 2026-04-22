using UnityEngine;

public class Libro : MonoBehaviour
{
    private bool cerca = false;

    public GameObject uiPapel;
    public GameObject uiMensajeGafas;
    public GameObject llave;

    void Start()
    {
        uiPapel.SetActive(false);
        llave.SetActive(false);
    }

    void Update()
    {
        if (cerca && Input.GetKeyDown(KeyCode.E))
        {
            if (Gafas.tieneGafas)
            {
                uiPapel.SetActive(true);
                llave.SetActive(true);
            }
            else
            {
                uiMensajeGafas.SetActive(true);
            }
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
}