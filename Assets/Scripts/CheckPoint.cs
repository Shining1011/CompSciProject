using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    #region Variables
    #endregion

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameManager.instance.CheckPoint = transform.position;
        }
    }
}
