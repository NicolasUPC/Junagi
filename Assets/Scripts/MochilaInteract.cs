using UnityEngine;

public class MochilaInteract : MonoBehaviour
{
    public GameObject mochila_C;
    public GameObject mochila_a;
    public GameObject llave;

    private bool cerca = false;

    void Update()
    {
        if (cerca && Input.GetKeyDown(KeyCode.E))
        {
            mochila_C.SetActive(false);
            mochila_a.SetActive(true);
            llave.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cerca = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cerca = false;
        }
    }
}