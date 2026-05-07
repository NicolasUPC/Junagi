using UnityEngine;

public class fuego : MonoBehaviour
{
    public ParticleSystem Fuego;
    public objectManager objectManager;
    public GameObject hojas;

    private bool estadoFuego = false;
    private bool cercaBonsai = false;

    void Start()
    {
        Fuego.Stop();
        Fuego.Clear();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && cercaBonsai)
        {
            // ENCENDER
            if (!estadoFuego)
            {
                if (objectManager.cerilla)
                {
                    Fuego.Play();
                    estadoFuego = true;

                    // Oculta las hojas
                    hojas.SetActive(false);

                    Debug.Log("El bonsái se está quemando");
                }
                else
                {
                    Debug.Log("Necesitas una cerilla");
                }
            }

            // APAGAR
            else
            {
                if (objectManager.extintor)
                {
                    Fuego.Stop(false, ParticleSystemStopBehavior.StopEmitting);

                    estadoFuego = false;

                    Debug.Log("Fuego apagado");
                }
                else
                {
                    Debug.Log("Necesitas un extintor");
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cercaBonsai = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cercaBonsai = false;
        }
    }
}