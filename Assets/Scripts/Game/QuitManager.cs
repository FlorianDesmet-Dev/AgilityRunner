using UnityEngine;

public class QuitManager : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Quit game");

        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif

        Application.Quit();
    }
}
