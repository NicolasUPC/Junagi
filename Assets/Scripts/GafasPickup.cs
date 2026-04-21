using UnityEngine;

public class GafasPickup : MonoBehaviour
{
    public objectManager objectManager;

    private bool cerca = false;

    void Update()
    {
        if (cerca && Input.GetKeyDown(KeyCode.E))
        {
            objectManager.gafas = true;  
            gameObject.SetActive(false);
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