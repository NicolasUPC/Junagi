using UnityEngine;

public class puertaFinal : MonoBehaviour
{
    private bool cercaPuertaFinal = false;
    public objectManager objectManager;
    public Animator animator;
    public Animator animatorUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (objectManager.llave9 && cercaPuertaFinal && Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("AbrirPuerta");
            animatorUI.SetTrigger("FondoBlanco");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cercaPuertaFinal = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cercaPuertaFinal = false;
        }
    }
}
