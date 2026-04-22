using UnityEngine;

public class SonidoDelay : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false; 
        audioSource.PlayDelayed(2f);
    }
}