using UnityEngine;

public class LlavePuerta2 : MonoBehaviour
{
    [Header("Configuración de las Puertas")]
    // Ahora puedes arrastrar tantos Animators y Colliders como quieras desde el Inspector
    public Animator[] animatorsPuertas;
    public Collider[] collidersPuertas;

    [Header("Configuración de la Llave")]
    public GameObject llave;

    private bool cercaDeLlave = false;
    private bool yaUsada = false;

    void Update()
    {
        // Detectar si el jugador pulsa E, está cerca y no ha usado la llave aún
        if (cercaDeLlave && !yaUsada && Input.GetKeyDown(KeyCode.E))
        {
            AbrirPuertas();
        }
    }

    void AbrirPuertas()
    {
        yaUsada = true;

        // 1. Activar la animación en TODAS las puertas de la lista
        if (animatorsPuertas != null)
        {
            foreach (Animator anim in animatorsPuertas)
            {
                if (anim != null)
                {
                    anim.SetTrigger("Abrir");
                }
            }
        }

        // 2. DESACTIVAR EL COLLIDER en TODAS las puertas de la lista (Para que el jugador pueda pasar)
        if (collidersPuertas != null)
        {
            foreach (Collider col in collidersPuertas)
            {
                if (col != null)
                {
                    col.enabled = false;
                    Debug.Log("Un collider de puerta ha sido desactivado.");
                }
            }
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
