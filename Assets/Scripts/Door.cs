using UnityEngine;

public class Door : Interactable
{
    #region Variables
    [SerializeField]
    private Transform destination;
    #endregion

    public override void Interact()
    {
        base.Interact();
        player.transform.position = destination.position;
    }
}
