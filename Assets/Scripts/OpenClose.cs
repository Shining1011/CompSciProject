using UnityEngine;

public class OpenClose : Interactable
{
    #region Variables
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private string openAnim;
    [SerializeField]
    private string closeAnim;
    private bool open = false;
    #endregion

    public override void Interact()
    {
        base.Interact();
        ToggleOpen();
    }

    private void ToggleOpen()
    {
        if (open)
        {
            Animations.instance.PlayAnimation(animator, closeAnim);
            open = false;
        }
        else
        {
            Animations.instance.PlayAnimation(animator, openAnim);
            open = true;
        }
    }
}
