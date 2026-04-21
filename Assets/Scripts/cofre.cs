using UnityEngine;

public class CofreInteractivo : MonoBehaviour
{
    public Transform jugador;          // Referencia al jugador
    public float distanciaActivacion = 3f;
    public Animator animator;

    private bool puedeInteractuar = false;

    void Update()
    {
        float distancia = Vector3.Distance(jugador.position, transform.position);

        // Verifica si el jugador está cerca
        if (distancia <= distanciaActivacion)
        {
            puedeInteractuar = true;

            // Detecta tecla E
            if (Input.GetKeyDown(KeyCode.E))
            {
                animator.SetBool("cofreAbierto", true);
            }
        }
        else
        {
            puedeInteractuar = false;
        }
    }
}