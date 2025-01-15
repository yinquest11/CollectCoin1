using UnityEngine;

public class Coin : MonoBehaviour
{
    public int Amount = 10;

    private Collider2D _collider2D;

    private AudioSource _audioSource;
    public GameObject Graphics;
    public AudioClip AudioClip;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _collider2D = GetComponent<Collider2D>();
        _audioSource = GetComponent<AudioSource>();

        if (_collider2D)
        {
            Debug.Log("2dcollider" + _collider2D);      
        }
    }

    private void OnMouseOver()
    {
        Debug.Log("We should Destory");


        if (_audioSource && AudioClip && !_audioSource.isPlaying) 
        {
            _audioSource.PlayOneShot(AudioClip);
        }

        if (Graphics)
        {
            Graphics.SetActive(false);
        }

        Invoke("Destroy", 1f);

    }


    void Destroy()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
