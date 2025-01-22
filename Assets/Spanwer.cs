using UnityEngine;

public class Spanwer : MonoBehaviour
{
    public GameObject CoinPerfab;
    
    public GameObject RareCoinPerfab;
    public Vector2 MinMaxPos;
    public float SpawnInterval = 0.5f;
    private bool isSpawning = false;
    private float spawnTimer;
    public int RareChance = 10;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Let the game start after 1 spwanTimer
        //spawnTimer = SpawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
            return;
        }

        int currentChance = Random.Range(0, 100);
        if (currentChance > RareChance)
        {
            if (CoinPerfab)
            {
                Vector3 randomSpawnPos = new Vector3(Random.Range(MinMaxPos.x, MinMaxPos.y),
                    transform.position.y,
                    transform.position.z);

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





        //if (CoinPerfab)
        //{
        //    Vector3 randomSpawnPos = new Vector3(Random.Range(MinMaxPos.x, MinMaxPos.y),
        //        transform.position.y, 
        //        transform.position.z);

        //    GameObject.Instantiate(CoinPerfab, randomSpawnPos, Quaternion.identity);
        }

        spawnTimer = SpawnInterval;


    }
}
