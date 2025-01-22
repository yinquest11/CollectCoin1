using UnityEngine;

public class OneShotSound : MonoBehaviour
{

    public AudioClip AudioClip;
    public float LifeTime = 1f;
    private AudioSource audioSource;
    private float timer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        if (audioSource && AudioClip && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(AudioClip);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (timer < LifeTime) 
        {
            timer += Time.deltaTime;
            
            return;
            
        }

        Destroy(gameObject);

    }
}
