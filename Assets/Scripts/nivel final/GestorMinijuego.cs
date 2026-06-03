using UnityEngine;

public class GestorMinijuego : MonoBehaviour
{
    [Header("Configuración 9ª Luz (Especial)")]
    public Renderer mallaLuzEspecial;       // El objeto 3D de la 9ª luz (especial)
    public Light luzPuntualEspecial;         // El Point Light de la 9ª luz
    public Material materialVerdeEspecial;   // Arrastra aquí el material 'luzVerdeYunagui'

    [Header("Animación de la Reja")]
    public Animator rejaAnimator;            // El Animator de la reja final

    private int cajasCompletadas = 0;
    public GameObject llaveFinal;

    void Start()
    {
        llaveFinal.SetActive(false);
    }

    // Función que llamará cada caja de forma automática al ser resuelta
    public void RegistrarCajaCompletada()
    {
        cajasCompletadas++;
        Debug.Log("Cajas completadas: " + cajasCompletadas + " / 8");

        // Cambiado a 8: ahora se activa al completar las 8 cajas iniciales
        if (cajasCompletadas >= 8)
        {
            CompletarMinijuego();
        }
    }

    void CompletarMinijuego()
    {
        Debug.Log("¡Minijuego completado! Abriendo reja final...");

        // 1. Cambiar material de la 9ª luz
        if (mallaLuzEspecial != null && materialVerdeEspecial != null)
        {
            mallaLuzEspecial.material = materialVerdeEspecial;
        }

        // 2. Cambiar el Tag del Point Light especial a "Verde"
        if (luzPuntualEspecial != null)
        {
            luzPuntualEspecial.gameObject.tag = "Verde";
        }

        // 3. Activar la animación de la reja (Trigger "Abrir")
        if (rejaAnimator != null)
        {
            rejaAnimator.SetTrigger("Abrir");
            llaveFinal.SetActive(true);
        }
    }
}
