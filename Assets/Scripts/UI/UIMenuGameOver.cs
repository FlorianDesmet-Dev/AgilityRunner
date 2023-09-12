using UnityEngine;
using UnityEngine.UI;

public class UIMenuGameOver : MonoBehaviour
{
    private Text score;
    private Text timeRemaining;

    private Button btnSubmit;

    private InputField username;

    private void Awake()
    {
        score = GameObject.Find("Score").GetComponent<Text>();
        timeRemaining = GameObject.Find("Time").GetComponent<Text>();

        btnSubmit = GameObject.Find("btn Submit").GetComponent<Button>();
        btnSubmit.enabled = false;

        username = GameObject.Find("InputField").GetComponent<InputField>();
    }

    private void OnEnable()
    {
        score.text = string.Format("Score : {0:00000}", ScoreManager.Instance.Score);

        float time = TimeManager.Instance.TimeRemaining;
        time += 1;
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        timeRemaining.text = string.Format("Time : {0:00}:{1:00}", minutes, seconds);
    }

    private void Update()
    {
        if (username.text != string.Empty)
        {
            btnSubmit.enabled = true;
        }
    }
}
