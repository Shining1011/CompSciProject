using UnityEngine;

public class Death : MonoBehaviour
{
    #region Variables
    private static Death instance;
    [SerializeField]
    private GameObject deathMenu;
    #endregion

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.K))
        {
            PlayerDie();
        }
    }

    public void PlayerDie()
    {
        deathMenu.SetActive(true);
    }
}
