using UnityEngine;

public class Spanwer : MonoBehaviour
{
    public GameObject CoinPerfab;
    public Vector2 MinMaxPos;
    public float SpawnInterval = 0.5f;
    private bool isSpawning = false;
    private float spawnTimer;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnTimer = SpawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
            return;
        }

        if (CoinPerfab)
        {
            Vector3 randomSpawnPos = new Vector3(Random.Range(MinMaxPos.x, MinMaxPos.y),
                transform.position.y, 
                transform.position.z);

            GameObject.Instantiate(CoinPerfab, randomSpawnPos, Quaternion.identity);
        }

        spawnTimer = SpawnInterval;


    }
}
