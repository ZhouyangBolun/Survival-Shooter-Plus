using UnityEngine;
using UnityEngine.UI;

public class HighscoresManager : MonoBehaviour {

    int[] score = new int[7];
    string[] scoreName = new string[7];
    public Text[] scoreUI = new Text[7];
    public Text[] scoreNameUI = new Text[7];

    public void UpdateHScore()
    {
        for(int i = 0; i < 7; i++)
        {
            score[i] = PlayerPrefs.GetInt(i + "HScore");
            scoreName[i] = PlayerPrefs.GetString(i + "HScoreName");
            scoreUI[i].text = score[i].ToString();
            scoreNameUI[i].text = scoreName[i];
        }
    }
}
