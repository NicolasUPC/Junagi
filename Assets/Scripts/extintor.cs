using UnityEngine;

public class extintor : MonoBehaviour
{
    private bool cerca = false;
    public objectManager objectManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (cerca && Input.GetKeyDown(KeyCode.E))
        {
            objectManager.extintor = true;
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            cerca = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            cerca = false;
    }
}
