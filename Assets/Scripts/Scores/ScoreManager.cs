using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    
    [SerializeField] private Text scoreText;

    public int Score { get; private set; }
    private float transitionSpeed = 25;
    float displayScore;

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

    private void Update()
    {
        displayScore = Mathf.MoveTowards(displayScore, Score, transitionSpeed * Time.deltaTime);
        UpdateScoreDisplay();
    }

    public void IncreaseScore(int amount)
    {
        Score += amount;
    }

    public void UpdateScoreDisplay()
    {
        scoreText.text = string.Format("{0:00000}", displayScore);
    }
}
