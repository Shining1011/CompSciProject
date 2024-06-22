using UnityEngine;

public class OptionsMenu_Buttons : MonoBehaviour
{
    #region Variables
    #endregion
    
    public void MasterVolume(float volume)
    {
        AudioManager.instance.SetMasterVolLvl(volume);
    }

    public void SFXVolume(float volume)
    {
        AudioManager.instance.SetSfxLvl(volume);
    }

    public void MusicVolume(float volume)
    {
        AudioManager.instance.SetMusicLvl(volume);
    }

    public void Brightness(float brightness)
    {
        GameManager.instance.AdjustBrightness(brightness);
    }
    public void Fullscreen(bool on)
    {
        GameManager.instance.Fullscreen(on);
    }
}
