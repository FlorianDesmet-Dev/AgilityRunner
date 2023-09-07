using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool start = false;
    
    [SerializeField] private GameObject menuGameOver;
    [SerializeField] private GameObject btnQuit;
    [SerializeField] private GameObject btnRetry;
    [SerializeField] private GameObject btnMenu;

    private void Awake()
    {
        menuGameOver.SetActive(false);
    }

    private void Update()
    {
        if (PlayerController.GameOver)
        {
            start = false;
            StartCoroutine(DisplayMenuGameOver());
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (PlayerController.GameOver)
            {
                Debug.Log("The game is over !");
            }
            else
            {
                start = true;
                Debug.Log("Game started !");
            }
        }
    }

    public void ResetTheGame()
    {
        start = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("The button is working");
    }

    private IEnumerator DisplayMenuGameOver()
    {
        yield return new WaitForSeconds(1);
        menuGameOver.SetActive(true);
        btnQuit.SetActive(true);
        btnRetry.SetActive(true);
        btnMenu.SetActive(true);
    }
}
