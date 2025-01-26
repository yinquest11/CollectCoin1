using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour

{
    //挂在一个空GameObject上,把脚本和Canvas的内容连接，控制游戏时长也控制UI的倒计时，并且决定倒计时之后会出现什么内容(UI)
    //挂在一个GameObject并且操控数个Text GameObject

    //控制游戏的游玩时长
    public float GameDuration = 10f;

    //游戏开始时会显示目前剩余时间,并改变CurrentTimeText所被赋予的Text GameObject
    public Text CurrentTimeText;

    //一个Text GameObject, 用来显示并联动最后的分数scoreManager.CurrentScore 然后赋值给FinalScoreText最后被显示
    //所以内容和scoreManager.CurrentScore时一样的
    public Text FinalScoreText;

    //创造GameObject数列，那么就可以一次过决定哪些GameObject要.SetActive(true)和.SetActive(false)
    //Element 0 就是第一个GameObject，以此类推
    public GameObject[] TurnOnWhenEnd;
    public GameObject[] TurnOfWhenEnd;

    //要引用ScoreManager class(组件)的.CurrentScore, 需要先创造这个Class的变量
    private ScoreManager scoreManager;

    //计时器，一直倒数的float变量
    private float timer;
    
    //开始的时候
    void Start()
    {
        //我们要先get ScoreManager这个组件(脚本)，然后引用赋值给scoreManager，有声明有get
        //首先找到ScoreManager这个GameObject，然后找到其中的ScoreManager组件(脚本)。一个脚本被挂在GameObject时被视为一个Component
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();

        //用public GameDuration来给timer赋值，决定从什么时候开始倒计时，timer是会一直变化的，所以最好用别的变量给他赋值避免在游戏中意外修改
        timer = GameDuration;

    }

    
    void Update()
    {
        //我们要timer计时器计算到0，所以当还是大过时，就会一直出发 -= Time.deltaTime; 
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            //timer扣除Time.deltaTime之后把CurrentTimeText所被赋予的Text GameObject的text换成目前timer的时间(剩余还有多少时间可以扣)
            if (CurrentTimeText)
            {
                CurrentTimeText.text = timer.ToString();

                //停止当前在使用的方法，在这个情况中也就是Update(),那么下一帧就会继续 扣除，显示，扣除，显示，...， 直到timer <= 0
                return;
            }

        }

        //当timer <= 0，不执行return时，便是游戏结束了，需要把在GameObject[]里的东西打开/关掉

        //在 public GameObject[] TurnOnWhenEnd; 数列里的所有element(GameObject)都会被一个一个被.SetActivate(true)，被   显示
        /*  
            1. panel-最后的面板
            2. 被写好"Times Up"的 Text GameObejct
            3. 被scoreManager.CurrentScore 赋值的 FinalScoreText 所代表的Text GameObject
         */
        for (int i = 0; i < TurnOnWhenEnd.Length; ++i)
        {
            TurnOnWhenEnd[i].SetActive(true);
        }

        //在 public GameObject[] TurnOfWhenEnd; 数列里的所有element(GameObject)都会被一个一个被.SetActivate(false)，被   关闭
        /*
            1. CurrentScore-用来显示后续分数和顶替"Score: "的ScoreManager类的public Text ScoreText; 所代表的Text GameObject 
            2. 显示剩余时间的CurrentTimeText所代表的GameObject
            3. Spawner GameObject
         
         */
        for (int i = 0; i < TurnOfWhenEnd.Length; ++i)
        {
            TurnOfWhenEnd[i].SetActive(false);
        }
        //同时也可以使用foreach函数，同样的原理

        //foreach (GameObject e in TurnOnWhenEnd)
        //{
        //    e.SetActive(true);
        //}

        //foreach (GameObject e in TurnOfWhenEnd)
        //{
        //    e.SetActive(false);
        //}

        //显示打开，关闭之后，将scoreManager.CurrentScore变成string然后赋值给代表FinalScoreText的 Text GameObject  
        if (scoreManager && CurrentTimeText) 
        {
            FinalScoreText.text = scoreManager.CurrentScore.ToString();        
        }

       

    }
}
