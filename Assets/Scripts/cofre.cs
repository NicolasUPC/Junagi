using UnityEngine;

public class CofreInteractivo : MonoBehaviour
{
    public Transform jugador;
    public float distanciaActivacion = 3f;
    public Animator animator;

    public static bool cofreAbierto = false; 

    void Update()
    {
        float distancia = Vector3.Distance(jugador.position, transform.position);

        if (distancia <= distanciaActivacion)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                animator.SetBool("cofreAbierto", true);
                cofreAbierto = true; 
            }
        }
    }
}