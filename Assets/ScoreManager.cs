using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int CurrentScore = 0;
    public Text ScoreText;

    public void AddScore(int score) 
    {
        CurrentScore += score;

        if (ScoreText)
        {
            ScoreText.text = "Score: " + CurrentScore.ToString();
        }
    
    
    }




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
