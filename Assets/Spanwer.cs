using UnityEngine;

public class Spanwer : MonoBehaviour
{
    //生成金币的Spawner GameObejct上的脚本，用来生成Coin

    //创建CoinPerfab，倒时可以引用这两个GameObject
    public GameObject CoinPerfab;
    public GameObject RareCoinPerfab;   
    
    //设置一个Vector2用来规定Vector3的x的范围，进而可以控制生成的x轴的范围，此y非彼y，这里只是当作另一个值再用，放进Random函数里
    public Vector2 MinMaxPos;
    
    //一个固定的值，用来每次重新赋给被改变了的spawnTimer
    public float SpawnInterval = 0.5f;
    
    //脚本里倒计时相关都是在改变spawnTimer的值
    private float spawnTimer;
    
    //设置一个初始值，用于设置RareCoinPerfab在0-99的概率，10=10/100，=0.1%
    public int RareChance = 10;

    

    
    void Start()
    {
        //当Start的时候，spawnTimer被赋予SpawnInterval，时间将延迟一个SpawnInterval再开始
        spawnTimer = SpawnInterval;
    }

    
    void Update()
    {
        //不断循环直到spawnTimer小过Time.deltaTime才继续接下来的行动
        if (spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
            return;
        }

        /*
            spawnTimer小过Time.deltaTime了，现在要分别随机的生产普通Coin和RareCoin，，要给他们设置概率，所以要设置Random,
            随机定义一个固定值RareChance=10,再随机生产一个0-99（一共100）个digit的currentChance，
            只有随机生成的currentChance小过定义的RareChance，概率只有10/100，因为0-99，只有10个digit符合>条件，
            0 1 2 3 4 5 6 7 8 9 
            如果随机生成的currentChance大于固定值（大概率），生产普通的Coin
            但如果随机生成的currentChance小于固定值（小概率），生产RareCoin
        */

        

        int currentChance = Random.Range(0, 100);
        if (currentChance > RareChance)
        {
            //如果CoinPerfab存在（true），实测不要放这个判断也可以
            if (CoinPerfab)
            {
                /*
                    调用unity自带的Vector3 class并生成一个randomSpawnPos的Object，由于GameObject.Instantiate
                    需要Vector3作为参数，所以这里使用Vector3来设定要生成的位置，最后这个Vector 3要放去GameObject.Instantiate静态函数
                */
                Vector3 randomSpawnPos = new Vector3(Random.Range(MinMaxPos.x, MinMaxPos.y),
                    transform.position.y,
                    transform.position.z);

                //调用GameObject.Instantiate静态函数并填入相应的参数来生成CoinPerfab
                GameObject.Instantiate(CoinPerfab, randomSpawnPos, Quaternion.identity);
            }
        }
        else 
        {
            
            if (RareCoinPerfab)
            {
                Vector3 randomSpawnPos = new Vector3(Random.Range(MinMaxPos.x, MinMaxPos.y),
                    transform.position.y,
                    transform.position.z);

                GameObject.Instantiate(RareCoinPerfab, randomSpawnPos, Quaternion.identity);
            }
        }


        //重置spawnTimer,并赋予SpawnInterval
        spawnTimer = SpawnInterval;
    }
}
