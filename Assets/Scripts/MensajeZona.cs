using UnityEngine;

public class MensajeZona : MonoBehaviour
{
    public GameObject mensaje;

    void Start()
    {
        mensaje.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mensaje.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mensaje.SetActive(false);
        }
    }
}