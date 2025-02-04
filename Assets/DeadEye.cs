using UnityEngine;

public class DeadEye : MonoBehaviour
{

    public AudioClip DeadEyeClip;
    public AudioSource deadEyeSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        deadEyeSource = GetComponent<AudioSource>();
        deadEyeSource.clip = DeadEyeClip;
        deadEyeSource.Play();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
