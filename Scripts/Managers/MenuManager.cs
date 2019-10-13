using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    public string pausedTitle = "PAUSED";
    public string resumeButtonText = "RESUME";
	public string playername = "JACK";

    public Text titleText;
    public Text buttonText;

    Canvas menuCanvas;
    Canvas hudCanvas;
    Canvas rankCanvas;

    bool gameHasStarted = false;
    

    void Start()
    {
        menuCanvas = GetComponent<Canvas>();
        hudCanvas = GameObject.Find("HUDCanvas").GetComponent<Canvas>();
        rankCanvas = GameObject.Find("RankCanvas").GetComponent<Canvas>();
        hudCanvas.enabled = false;
        rankCanvas.enabled = false;
        Time.timeScale = 0;
        AddScore("",0);
        ChangeName(GameObject.Find("InputField").GetComponent<InputField>().textComponent);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameHasStarted = true;
            Pause();
        }
    }

    public void Pause()
    {
        menuCanvas.enabled = !menuCanvas.enabled;
        hudCanvas.enabled = !hudCanvas.enabled;
        if (rankCanvas.enabled)
        {
            rankCanvas.enabled = !rankCanvas.enabled;
        }

        Time.timeScale = Time.timeScale == 0 ? 1 : 0;

        if (gameHasStarted)
        {
            titleText.text = pausedTitle;
            buttonText.text = resumeButtonText;
        }
    }

    public void Rank()
    {
        rankCanvas.enabled = !rankCanvas.enabled;
        GameObject.Find("RankCanvas").GetComponent<HighscoresManager>().UpdateHScore();
    }

    public void ChangeName(Text t)
    {
        playername = t.text;
        Debug.Log("name changed:" + playername);
    }

    public void AddScore(string name, int score)
    {
        int newScore;
        string newName;
        int oldScore;
        string oldName;
        newScore = score;
        newName = name;
        for (int i = 0; i < 7; i++)
        {
            if (PlayerPrefs.HasKey(i + "HScore"))
            {
                if (PlayerPrefs.GetInt(i + "HScore") < newScore)
                {
                    oldScore = PlayerPrefs.GetInt(i + "HScore");
                    oldName = PlayerPrefs.GetString(i + "HScoreName");
                    PlayerPrefs.SetInt(i + "HScore", newScore);
                    PlayerPrefs.SetString(i + "HScoreName", newName);
                    newScore = oldScore;
                    newName = oldName;
                }
            }
            else
            {
                PlayerPrefs.SetInt(i + "HScore", newScore);
                PlayerPrefs.SetString(i + "HScoreName", newName);
                newScore = 0;
                newName = "";
            }
        }
    }

    public void GameExit()
    {
        Application.Quit();
        Debug.Log("game exit");
    }
}
