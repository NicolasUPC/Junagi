using UnityEngine;

public class habitacion8 : MonoBehaviour
{
    [Header("Configuración de la Puerta")]
    public Animator puertaAnim;    
    public Collider colisionPuerta; 

    [Header("Configuración de la Llave")]
    public GameObject llave8;

    private bool cercaDeLlave = false;
    private bool yaUsada = false;

    public fuego[] fuegos;
    public fuego5 fuegoh5;

    void Update()
    {
        // Detectar si el jugador pulsa E, está cerca y no ha usado la llave aún
        if (cercaDeLlave && !yaUsada && Input.GetKeyDown(KeyCode.E))
        {
            if (BonsaisApagados())
            {
                AbrirPuerta();
            }
            else
            {
                Debug.Log("Apaga todos los bonsais para poder coger la llave");
            }
        }
    }
    public bool BonsaisApagados()
    {
        foreach (fuego fire in fuegos)
        {
            if (fire != null && fire.estadoFuego)
            {
                return false;
            }
        }

        if (fuegoh5 != null && fuegoh5.estadoFuego)
        {
            return false;
        }

        return true;
    }

    void AbrirPuerta()
    {
        yaUsada = true;

        // Activar la animación
        if (puertaAnim != null)
        {
            puertaAnim.SetTrigger("Abrir");
        }

        // DESACTIVAR EL COLLIDER (Para que el jugador pueda pasar)
        if (colisionPuerta != null)
        {
            colisionPuerta.enabled = false;
            Debug.Log("Collider de la puerta desactivado.");
        }

        // Eliminar la llave visualmente
        if (llave8 != null)
        {
            Destroy(llave8);
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

