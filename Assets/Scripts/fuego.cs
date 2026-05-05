using UnityEngine;
using System.Collections;

public class fuego : MonoBehaviour
{
	public ParticleSystem Fuego;
	private ParticleSystemRenderer fuegoRenderer;
	private bool estadoFuego = false;
	private bool cercaBonsai = false;
	public objectManager objectManager;
	public GameObject hojas;

	void Start()
	{
		Fuego.Stop();
		Fuego.Clear();
	}
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.E) && cercaBonsai == true)
		{
			if (estadoFuego == false && objectManager.cerilla == true)
			{
				Fuego.Play();
				estadoFuego = true;
				Destroy(hojas);
			}
			if (estadoFuego == true && objectManager.extintor == true)
			{
				Fuego.Stop(false, ParticleSystemStopBehavior.StopEmitting);
				estadoFuego = false;
			}
			if (estadoFuego == false && objectManager.cerilla == false)
			{
				//print de que el jugador necesita la cerilla para quemar el bonsái
			}
			if (estadoFuego == true && objectManager.extintor == false)
			{
				//print de que el jugador necesita el extintor para apagar el fuego del bonsái
			}
			if(estadoFuego == false)
            {
				Fuego.Stop(false, ParticleSystemStopBehavior.StopEmitting);
			}
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			cercaBonsai = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			cercaBonsai = false;
		}
	}
}
