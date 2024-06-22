using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class ProgressManager : MonoBehaviour
{
    #region Variables
    public static ProgressManager instance;
    [SerializeField]
    private Transform playerTransform;
    #endregion

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void SaveGame()
    {
        SaveSystem.SavePlayer(GameManager.instance.CheckPoint, SceneManager.GetActiveScene().name, GameManager.instance.PlayerName);
    }

    public void LoadGame()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        SceneManagement.instance.LoadScene(data.currentScene);
        GameManager.instance.PlayerName = data.playerName;
        playerTransform.position = new Vector3(data.playerPos[0], data.playerPos[1], 0f);
    }
        
    public void NewGame()
    {
        SaveSystem.SavePlayer(Vector3.zero, "StartingArea", "");
        LoadGame();
    }
}

[System.Serializable]
public class PlayerData
{
    public float[] playerPos;
    public string playerName;
    public string currentScene;

    public PlayerData(Vector3 playerTransform, string sceneName, string name)
    {
        playerName = name;
        currentScene = sceneName;
        playerPos = new float[2];
        playerPos[0] = playerTransform.x; 
        playerPos[1] = playerTransform.y;
    }
}

public static class SaveSystem
{
    public static void SavePlayer(Vector3 playerTransform, string sceneName, string name)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(playerTransform, sceneName, name);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer(){
        string path = Application.persistentDataPath + "/player.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
