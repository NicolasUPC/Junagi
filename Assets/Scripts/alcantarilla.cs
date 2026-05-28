using UnityEngine;

public class alcantarilla : MonoBehaviour
{
    public float[] posX;
    public float[] posZ;
    public float[] rotY;
    private int interactionCount;
    private bool jugadorCerca = false;
    public bool alcantarillaAbierta = false;
    public Animator animator;
    public GameObject Alcantarilla;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (jugadorCerca && Input.GetKeyDown(KeyCode.E))
        {
            Interactuar();
        }
    }
    void Interactuar()
    {
        interactionCount++;
        Vector3 posicionActual = transform.position;
        if (interactionCount == 1)
        {
            Alcantarilla.transform.position = new Vector3(posX[0],posicionActual.y,posZ[0]);
            Alcantarilla.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, rotY[0], transform.rotation.eulerAngles.z);
        }
        if (interactionCount == 2)
        {
            Alcantarilla.transform.position = new Vector3(posX[1], posicionActual.y, posZ[1]);
            Alcantarilla.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, rotY[1], transform.rotation.eulerAngles.z);
        }
        if (interactionCount == 3)
        {
            Alcantarilla.transform.position = new Vector3(posX[2], posicionActual.y, posZ[2]);
            Alcantarilla.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, rotY[2], transform.rotation.eulerAngles.z);
            alcantarillaAbierta = true;
            animator.SetBool("alcantarillaAbierta", true);
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
