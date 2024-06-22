using UnityEngine;

public class HomeMenu_Buttons : MonoBehaviour
{
    #region Variables
    #endregion
    
    public void NewGame()
    {
        ProgressManager.instance.NewGame();
    }

    public void LoadGame()
    {
        ProgressManager.instance.LoadGame();
    }

    public void Exit()
    {
        GameManager.instance.ExitGame();
    }
}
