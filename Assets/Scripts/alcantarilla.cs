using UnityEngine;

public class alcantarilla : MonoBehaviour
{
    private int interactionCount;
    private bool jugadorCerca = false;
    public bool alcantarillaAbierta = false;
    public Animator animator;
    public GameObject Alcantarilla;
    public GameObject llave6;
    public GameObject llave6falsa;
    public objectManager objectManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        llave6.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (jugadorCerca && Input.GetKeyDown(KeyCode.E))
        {
            if (objectManager.iman && objectManager.hilo)
            {
                Interactuar();
            }
            else
            {
                Debug.Log("Necesitas el hilo y el imán para alcanzar la tarjeta");
            }
        }
    }
    void Interactuar()
    {
        interactionCount++;
        if (interactionCount == 1)
        {
            animator.SetInteger("interactionCount", 1);
        }
        if (interactionCount == 2)
        {
            animator.SetInteger("interactionCount", 2);
        }
        if (interactionCount == 3)
        {
            animator.SetInteger("interactionCount", 3);
            alcantarillaAbierta = true;
            animator.SetBool("alcantarillaAbierta", true);
            llave6.SetActive(true);
        }
        if (interactionCount == 4)
        {
            Destroy(llave6falsa);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;
        }
    }
}
