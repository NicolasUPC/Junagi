using UnityEngine;

public class CofreInteractivo : MonoBehaviour
{
    public Transform jugador;
    public float distanciaActivacion = 3f;
    public Animator animator;

    public GameObject gafas; 

    public static bool cofreAbierto = false;

    void Update()
    {
        float distancia = Vector3.Distance(jugador.position, transform.position);

        if (distancia <= distanciaActivacion && !cofreAbierto)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Cofre abierto");

                animator.SetBool("cofreAbierto", true);
                cofreAbierto = true;

                gafas.SetActive(true); 
            }
        }
    }
}