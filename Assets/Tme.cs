using UnityEngine;

public class Tme : MonoBehaviour
{
    public AudioClip Clip;
    private AudioSource source;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        source = GetComponent<AudioSource>();
        if (Clip && source) 
        {
            source.PlayOneShot(Clip);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
