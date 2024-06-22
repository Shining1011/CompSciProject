using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    #region Variables
    public static AudioManager instance;
    [SerializeField]
    private AudioMixer masterMixer;
    #endregion

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void SetMasterVolLvl(float masterVolLvl)
    {
        masterMixer.SetFloat("masterVol", masterVolLvl);
    }

    public void SetSfxLvl(float sfxLvl)
    {
        masterMixer.SetFloat("sfxVol", sfxLvl);
    }

    public void SetMusicLvl(float musicLvl)
    {
        masterMixer.SetFloat("musicVol", musicLvl);
    }
}
