using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;

    float countTime;
    bool bgchange = true;
    void Start ()
    {
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }


    void Spawn ()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }
        countTime += Time.deltaTime;
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        //Debug.Log(spawnTime);
        if ((countTime-0.1) > 0 && spawnTime != 1)
        {
            spawnTime = spawnTime - 1;
            countTime = 0;
        }
        if((spawnTime == 1) && bgchange)
        {
            GameObject.Find("BackgroundMusic").GetComponent<MusicManager>().Change();
            bgchange = false;
        }
    }
}
