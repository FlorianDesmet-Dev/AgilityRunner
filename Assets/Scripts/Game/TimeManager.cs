using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance { get; private set; }

    [SerializeField] private Text timeText;

    public float TimeRemaining { get; private set; }
    private bool timerIsRunning = false;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        timerIsRunning = false;
    }

    private void Update()
    {
        if (GameManager.start)
        {
            timerIsRunning = true;
        }
        else
        {
            timerIsRunning = false;
        }

        if (timerIsRunning)
        {
            TimeRemaining += Time.deltaTime;
            DisplayTime(TimeRemaining);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
