using UnityEngine;
using System.Collections;

public class fuego : MonoBehaviour
{
	public ParticleSystem Fuego;
	private ParticleSystemRenderer fuegoRenderer;
	private bool estadoFuego = false;
	public bool cerilla = true;
	public bool extintor = true;

	void Start()
	{
		//Fuego.Stop(true, ParticleSystemBehavior.StopEmittingClear);
	}
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			if (estadoFuego == false && cerilla == true)
			{
				Fuego.Play();
				estadoFuego = true;
			}
			if (estadoFuego == true && extintor == true)
			{
				Fuego.Stop(false, ParticleSystemStopBehavior.StopEmitting);
				estadoFuego = false;
			}
			if (estadoFuego == false && cerilla == false)
			{
				//print de que el jugador necesita la cerilla para quemar el bonsái
			}
			if (estadoFuego == true && extintor == false)
			{
				//print de que el jugador necesita el extintor para apagar el fuego del bonsái
			}
		}
	}
}
