using UnityEngine;
using UnityEngine.UI;

public class InventarioManager : MonoBehaviour
{
    public static InventarioManager Instancia;

    [Header("Configuración del Inventario")]
    public Transform contenedorUI; // Aquí arrastraremos el panel InventarioUI
    public GameObject prefabIcono; // Aquí arrastraremos el molde IconoItem

    private void Awake()
    {
        // Esto permite que cualquier objeto llame al inventario fácilmente
        if (Instancia == null) Instancia = this;
    }

    public void AñadirObjeto(Sprite imagenDelObjeto)
    {
        // Creamos una copia del molde de la imagen dentro del panel
        GameObject nuevoIcono = Instantiate(prefabIcono, contenedorUI);

        // Le asignamos la foto del objeto que acabamos de recoger
        nuevoIcono.GetComponent<Image>().sprite = imagenDelObjeto;
    }
}