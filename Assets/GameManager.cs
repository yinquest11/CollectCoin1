using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
    

    
{
    public float GameDuration = 10f;
    public Text CurrentTimeText;
    public Text FinalScoreText;
    public GameObject[] TurnOnWhenEnd;
    public GameObject[] TurnOfWhenEnd;

    private ScoreManager scoreManager;

    public float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        
        timer = GameDuration;

    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (CurrentTimeText) 
            {
                CurrentTimeText.text = timer.ToString();
                return;
            }
        }

        if (CurrentTimeText) 
        {
            CurrentTimeText.text = "Times Up";
        }

        for (int i = 0; i < TurnOnWhenEnd.Length; ++i) 
        {
            TurnOnWhenEnd[i].SetActive(true);
        }
        for (int i = 0; i < TurnOfWhenEnd.Length; ++i)
        {
            TurnOfWhenEnd[i].SetActive(false);
        }

        if (scoreManager && CurrentTimeText) 
        {
            FinalScoreText.text = scoreManager.CurrentScore.ToString();        
        }



    }
}
