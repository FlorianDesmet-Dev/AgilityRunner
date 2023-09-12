using UnityEngine;

public class PauseControl : MonoBehaviour
{
    public static PauseControl Instance { get; private set; }
    [SerializeField] private GameObject pauseGameObject;

    private bool GameIsPaused;

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

        GameIsPaused = false;
        pauseGameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameManager.start)
        {
            GameIsPaused = !GameIsPaused;
            PauseGame();
        }
    }
    void PauseGame()
    {
        if (GameIsPaused)
        {
            Debug.Log("Game is paused");
            Time.timeScale = 0f;
            pauseGameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseGameObject.SetActive(false);
        }
    }
}
