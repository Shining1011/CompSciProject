using UnityEngine;

public class Animations : MonoBehaviour
{
    #region Variables
    public static Animations instance;
    #endregion
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void PlayAnimation(Animator anim, string animation)
    {
        if (anim.GetCurrentAnimatorClipInfo(0)[0].clip.name != animation)
        {
            anim.Play(animation);
        }
    }
}
