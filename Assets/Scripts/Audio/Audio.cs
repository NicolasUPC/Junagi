using UnityEngine;

public class Repaudio : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    AudioSource raudio;

    public bool reproducido;
    void Start()
    {
        raudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnTriggerEnter()
    {
        if (!reproducido)
        {
            raudio.Play();
            reproducido = true;
        }
    }
    /*void OnTriggerExit()
    {
        raudio.Stop();
    }*/
}
