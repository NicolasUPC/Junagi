using UnityEngine;
using UnityEngine.UI;

public class InventarioManager : MonoBehaviour
{
    public GameObject itemPrefab; // Arrastra aquí tu prefab 'ItemSlot'
    public Transform contenedor;  // Arrastra aquí el 'InventarioContenedor'

    // Función para añadir el objeto visualmente
    public void AñadirObjetoAlInventario(Sprite iconoDelObjeto)
    {
        // Instanciamos el prefab como hijo del contenedor
        GameObject nuevoItem = Instantiate(itemPrefab, contenedor);

        // Buscamos el componente Image y le asignamos el sprite del objeto cogido
        nuevoItem.GetComponent<Image>().sprite = iconoDelObjeto;
    }
}