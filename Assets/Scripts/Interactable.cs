using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    #region Variables
    private bool canInteract = false;
    protected GameObject player;
    public static GameObject eToInteractText;
    #endregion


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(player == null)
            {
                player = collision.gameObject;
            }
            GameManager.instance.eToInteractText.SetActive(true);
            canInteract = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameManager.instance.eToInteractText.SetActive(false);
            canInteract = false;
        }
    }

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    public virtual void Interact()
    {
    }
}
