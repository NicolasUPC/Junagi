using UnityEngine;

public class ObjetoRecogible : MonoBehaviour
{
    [Header("Apariencia en el Inventario")]
    public Sprite imagenParaElInventario; // La foto que aparecerá en la pantalla

    private bool jugadorCerca = false; // Nos dice si el jugador está en zona

    private void Update()
    {
        // Si el jugador está cerca Y presiona la tecla E
        if (jugadorCerca && Input.GetKeyDown(KeyCode.E))
        {
            Interactuar();
        }
    }

    private void Interactuar()
    {
        // Avisamos al inventario para que muestre la imagen
        InventarioManager.Instancia.AñadirObjeto(imagenParaElInventario);

        // Destruimos el objeto del escenario
        Destroy(gameObject);
    }

    // Al entrar en la zona (Trigger)
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
        }
    }

    // Al salir de la zona (Trigger)
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;
        }
    }
}