using UnityEngine;
using UnityEngine.SceneManagement;
public class GoHomeS : MonoBehaviour
{
    public string Home;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void hh()
    {
        

        SceneManager.LoadScene(Home);
        }
}
