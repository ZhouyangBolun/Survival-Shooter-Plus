using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float restartDelay = 10f;
    Animator anim;
    float restartTimer;
    bool AddScoreTrigger = false;
    string playername;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {

        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("GameOver");
            restartTimer += Time.deltaTime;
            if (!AddScoreTrigger)
            {
                playername = GameObject.Find("MenuCanvas").GetComponent<MenuManager>().playername;
                GameObject.Find("MenuCanvas").GetComponent<MenuManager>().AddScore(playername, ScoreManager.score);
                AddScoreTrigger = true;
            }
            
            if (restartTimer >= restartDelay)
            {
                AddScoreTrigger = false;
                SceneManager.LoadScene(0);
            }
        }
    }
}
