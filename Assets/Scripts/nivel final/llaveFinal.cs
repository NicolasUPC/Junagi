using UnityEngine;

public class llaveFinal : MonoBehaviour
{
    public GameObject llave;
    public GameObject llaveFinalFalsa;
    private bool cercaDeLlave = false;
    public objectManager objectManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cercaDeLlave && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(llaveFinalFalsa);
            Destroy(llave);
            objectManager.llave9 = true;
        }
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
