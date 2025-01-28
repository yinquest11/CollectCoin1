using UnityEngine;

public class Coin : MonoBehaviour
{
    //挂在金币GameObject的脚本，用来设定金币的行为

    //设置每个Coin可以获得的份数，在Rare Coin的情况，会被inspector设置成100 
    public int Amount = 10;
    //private Component 变量名字；有写有get 写
    private Collider2D _collider2D;

    //public 因为到时候要拖拽引用这个GameObject， 我们将会拖拽Coin这个物品的皮肤，本来是Hexagon，然后Sprite Rendere, sprite被替换成Coin的Graphic
    public GameObject Graphics;


    /*
    void OnMouseOver()时，将会GameObject.Instantiate 这个GameObject.
    DeathSound 也就是 Coin Sound, Coin Sound这个GameObject里有OneShotSound,被创建的时候会有声音
    */
     public GameObject DeathSound;

    //void OnMouseOver()时，将会GameObject.Instantiate这个GameObject，这是Unity自带的GameObject,被生成就是播放
    public GameObject DeathPartice;

    //为了调用 scoreManager.AddScore，所以先使用ScoreManager class，(另一个我们的script)
    private ScoreManager scoreManager;

    public bool destroy = true;

    public float timer = 2f;



    //当游戏开始的时候
    void Start()
    {
        /*
            有写有get get. Get到当前脚本挂载对象的组件然后引用给_collider2D这个名字
            才可以透过这个变量名字引用这个Component的class,进行操作
        */
        _collider2D = gameObject.GetComponent<Collider2D>();

        /*
            继承自MonoBehaviour的脚本会被视为一个GameObject的Component
            所以这里也是和引用别的Component一样，现在要引用别的GameObject的Component(脚本)
            之前有声明过是哪个class(脚本)，现在需要找到这个Component(脚本)引用给变量名字scoreManager,方便后面控制
            在哪里一个GameObject里面找这个Component
         */
        scoreManager = GameObject.FindWithTag("ScoreManager").GetComponent<ScoreManager>();

        //当_collider2D不为null, 有value“gameObject.GetComponent<Collider2D>();”，就可以执行
        if (_collider2D)
        {
            //+ _collider2D会显示它所引用的Collider2D组件出自哪个GameObject，(Clone)是因为是通过Insantiate出来的
            //赋值_collider2D的时候是通过gameObjcect.GetComponent<Collider2D>();, 所以是gameObject，这里的gameObject是Coin
            Debug.Log("2dcollider" + _collider2D);      
        }
    }

    //当gameObject被鼠标悬浮在上面的时候
    private void OnMouseOver()
    {
        //若DeathSound有被找到，存在，则，创建这个GameObject (GameObject DeathSound;)，这个声音是来自Coin Sound, Coin是一个播放声音的Game Object
        if (DeathSound)
        {
            if (destroy == true)
            {
                GameObject.Instantiate(DeathSound, gameObject.transform.position, gameObject.transform.rotation);
            }
           
        }

        //若DeathParticle有被找到，存在，则，创建这个GameObject (GameObject DeathParticle;)
        if (DeathPartice)
        {

            if (destroy == true)
            {
                GameObject.Instantiate(DeathPartice, gameObject.transform.position, gameObject.transform.rotation);
            }

         
        }

        //当scoreManager这个组件(脚本)被GetComponent到，则使用这个class(组件)的public method .AddScore 然后填入 public int Amount = 10;

        if (destroy == true)
        {
             if (scoreManager)
            {
                scoreManager.AddScore(Amount);
            }

        //要执行处理需要放在一个函数，方法里
        //Insantiate 音效，粒子。计分.AddScore()之后,调用来自Object类的静态方法(静态可以直接调用)，Destory 当前的被挂载脚本的GameObject既gameObject;
        

        Destroy(gameObject);

        }
    }

    


    

}
