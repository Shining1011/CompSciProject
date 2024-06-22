using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject deathMenu;
    private bool paused = false;
    
    #endregion

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            string sn = SceneManager.GetActiveScene().name;
            if (sn != "HomeMenu" && sn != "LoadScreen" && !deathMenu.activeInHierarchy)
            {
                TogglePause();
            }
        }
    }
    public void TogglePause()
    {
        if (paused)
        {
            pauseMenu.SetActive(false);
            paused = false;
            Time.timeScale = 1f;
        }
        else
        {
            pauseMenu.SetActive(true);
            paused = true;
            Time.timeScale = 0f;
        }
    }
}
