using UnityEngine;
using UnityEngine.UI;

public class HighScoreDisplay : MonoBehaviour
{
    [SerializeField] private Text nameText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text timeText;

    public void DisplayHighScore(string name, int score, float time)
    {
        nameText.text = name;
        scoreText.text = string.Format("{0:000000}", score);

        time += 1;
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void HideEntryDisplay()
    {
        nameText.text = "";
        scoreText.text = "";
        timeText.text = "";
    }
}

[System.Serializable]
public class HighScoreEntry
{
    public string name;
    public int score;
    public float time;
}
