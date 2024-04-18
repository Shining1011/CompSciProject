using UnityEngine;

public class Interactable : MonoBehaviour
{
    #region Variables
    private bool canInteract = false;
    protected GameObject player;
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(player == null)
            {
                player = collision.gameObject;
            }
            canInteract = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
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
        Debug.Log("Interacted");
    }
}
