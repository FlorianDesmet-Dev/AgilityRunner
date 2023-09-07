using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    [SerializeField] private HighScoreDisplay[] highScoreDisplayArray;
    private List<HighScoreEntry> scores = new List<HighScoreEntry>();

    [SerializeField] private InputField ifUsername;

    private string username;
    private int score;
    private float time;

    private void Start()
    {
        Load();
        score = ScoreManager.Instance.Score;
        username = ifUsername.text;
        time = TimeManager.Instance.TimeRemaining;
        
        AddNewScore(username, score, time);
        UpdateDisplay();
        Save();
    }

    public void UpdateDisplay()
    {
        scores.Sort((HighScoreEntry x, HighScoreEntry y) => y.score.CompareTo(x.score));

        for (int i = 0; i < highScoreDisplayArray.Length; i++)
        {
            if (i < scores.Count)
            {
                highScoreDisplayArray[i].DisplayHighScore(scores[i].name, scores[i].score, scores[i].time);
            }
            else
            {
                highScoreDisplayArray[i].HideEntryDisplay();
            }
        }
    }

    public void Load()
    {
        scores = JSONManager.Instance.LoadFromJson();
        // scores = XMLManager.Instance.LoadScores();
    }

    public void Save()
    {
        JSONManager.Instance.SaveToJson(scores);
        // XMLManager.Instance.SaveScores(scores);
    }

    public void AddNewScore(string entryName, int entryScore, float entryTime)
    {
        scores.Add(new HighScoreEntry { name = entryName, score = entryScore, time = entryTime });
    }

    private void OnDisable()
    {
        // Save();
    }
}
