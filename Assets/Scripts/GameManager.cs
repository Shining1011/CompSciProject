using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Variables
    public static GameManager instance;
    [SerializeField]
    private Image brightnessLayer;
    public GameObject eToInteractText;
    private string playerName;
    private Vector2 checkPoint = Vector2.zero;

    public string PlayerName
    {
        get { return playerName; }
        set { playerName = value; }
    }

    public Vector2 CheckPoint
    {
        get { return checkPoint; }
        set { checkPoint = value; }
    }
    #endregion

    private void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(gameObject);
        Interactable.eToInteractText = eToInteractText;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Fullscreen(bool full)
    {
        if (full) {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
    }

    public void AdjustBrightness (float brightness)
    {
        brightnessLayer.color = new Color(0, 0, 0, -brightness/100f);
    }
}
