using UnityEngine;

public class TriggerUltimaSala : MonoBehaviour
{
    private bool activado = false;

    void OnTriggerEnter(Collider other)
    {
        // Si el jugador cruza la puerta y no se ha activado antes
        if (!activado && other.CompareTag("Player"))
        {
            activado = true;
            Debug.Log("¡Jugador ha entrado a la última sala! Activando minijuego...");

            // Busca todas las cajas que tengan el script 'CajaMinijuego' en la escena y las abre
            CajaMinijuego[] todasLasCajas = Object.FindObjectsByType<CajaMinijuego>(FindObjectsSortMode.None);

            foreach (CajaMinijuego caja in todasLasCajas)
            {
                if (caja != null)
                {
                    caja.EntrarEnHabitacion();
                }
            }

            // Desactiva este trigger para ahorrar recursos ya que cumplió su función
            gameObject.SetActive(false);
        }
    }
}
