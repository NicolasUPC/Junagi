using UnityEngine;

public class puertaFinal : MonoBehaviour
{
    private bool cercaPuertaFinal = false;
    private bool activado = false;

    public objectManager objectManager; // Tu script que comprueba las llaves
    public Animator animator;           // El Animator de la puerta física

    void Update()
    {
        // Si no se ha abierto, tienes la llave 9, estás cerca y pulsas la E
        if (!activado &&
            objectManager != null &&
            objectManager.llave9 &&
            cercaPuertaFinal &&
            Input.GetKeyDown(KeyCode.E))
        {
            activado = true;

            // Abrimos la puerta física de forma independiente
            if (animator != null)
            {
                animator.SetTrigger("AbrirPuerta");
            }

            Debug.Log("¡Puerta abierta con éxito con la Llave 9!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            cercaPuertaFinal = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            cercaPuertaFinal = false;
    }
}

