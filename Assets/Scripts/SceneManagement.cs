using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class SceneManagement : MonoBehaviour 
{
    #region Variables
    public static SceneManagement instance;
    [SerializeField]
    private GameObject player;
    #endregion

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void LoadHomeMenu()
    {
        ProgressManager.instance.SaveGame();
        StartCoroutine(LoadLevelAsync("HomeMenu"));
    }
    public void LoadScene(string scene)
    {
        StartCoroutine(LoadLevelAsync(scene));
        
    }

    public IEnumerator LoadLevelAsync(string levelName)
    {
        player.SetActive(false);
        yield return SceneManager.LoadSceneAsync("LoadScreen", LoadSceneMode.Single);
        Slider loadBar = GameObject.FindGameObjectWithTag("LoadBar").GetComponent<Slider>();
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            loadBar.value = progress;
            Debug.Log(progress);
            yield return null;
        }
        SceneManager.UnloadSceneAsync("LoadScreen");
        
        if (levelName != "HomeMenu")
        {
            player.SetActive(true);
        }
        //Debug.Log(player.activeInHierarchy);
    }
}
