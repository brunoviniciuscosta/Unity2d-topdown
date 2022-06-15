using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int scoreValue = 0;
    public Text score;
    public Text highScore;

    private void Start()
    {
        score.text = "0";
        highScore.text = "Highscore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    private void Update()
    {
        score.text = "Score: " + scoreValue;
        checkHigh();
    }

    void checkHigh()
    {
        if (scoreValue > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", scoreValue);
            highScore.text = "Highscore: " + scoreValue.ToString();
        }
    }
}
