using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JSONManager : MonoBehaviour
{
    public static JSONManager Instance { get; private set; }

    private ScoresBoard scoresBoard = new ScoresBoard();

    private string key = "pCmA4L3kRW023WdBk0Dd9TiSIwTTYjHACLEa4F6LpLgQSs6BYeOvJoP10PDNFf2";
    private string crypted = "";
    private string decrypted = "";

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

    string Encrypt(string data)
    {
        for (int i = 0; i < data.Length; i++)
        {
            crypted += (char)(data[i] ^ key[i % key.Length]);
        }
        return crypted;
    }

    string Decrypt(string data)
    {
        for (int i = 0; i < data.Length; i++)
        {
            decrypted += (char)(data[i] ^ key[i % key.Length]);
        }
        return decrypted;
    }

    public void SaveToJson(List<HighScoreEntry> scoresToSave)
    {
        scoresBoard.list = scoresToSave;        
        string leaderBoardData = JsonUtility.ToJson(scoresBoard);
        crypted = Encrypt(leaderBoardData);
        string filePath = Application.persistentDataPath + "/ScoresData.json";
        Debug.Log(filePath);
        
        File.WriteAllText(filePath, crypted);
        Debug.Log("Sauvegarde effectuée");
    }

    public List<HighScoreEntry> LoadFromJson()
    {
        string filePath = Application.persistentDataPath + "/ScoresData.json";
        string leaderBoardData = File.ReadAllText(filePath);

        decrypted = Decrypt(leaderBoardData);

        scoresBoard = JsonUtility.FromJson<ScoresBoard>(decrypted);
        Debug.Log("Chargement effectué");
        return scoresBoard.list;
    }

    [System.Serializable]
    public class ScoresBoard
    {
        public List<HighScoreEntry> list = new List<HighScoreEntry>();
    }
}
