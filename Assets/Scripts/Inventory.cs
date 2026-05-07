
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    public List<string> items = new List<string>();

    void Awake()
    {
        instance = this;
    }

    public void AddItem(string item)
    {
        items.Add(item);
        Debug.Log("Añadido: " + item);
    }
}
