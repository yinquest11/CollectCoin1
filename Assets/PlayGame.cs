using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public string sc;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void GoPlay() 
    {
        SceneManager.LoadScene(sc);
    }
}
