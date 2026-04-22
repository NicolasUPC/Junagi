using UnityEngine;

public class UIMensajeGafas : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            gameObject.SetActive(false);
        }
    }
}