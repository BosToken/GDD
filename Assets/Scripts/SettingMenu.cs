using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public Toggle musicToggle;
    public Toggle sfxToggle;
    public bool isMusicOn = true;
    public bool isSfxOn = true;
    GameObject setPan;
    [SerializeField] private AudioSource mBgm;
    void Start()
    {
        mBgm.Play();
        setPan = GameObject.Find("SettingPanel");
        if (isMusicOn == true)
        {
            musicToggle.isOn = true;
            mBgm.Play();
        } else {
            musicToggle.isOn = false;
            mBgm.Pause();
        }
        setPan.SetActive(false);
    }
    public void music()
    {
        if (musicToggle.isOn)
        {
            isMusicOn = true;
            mBgm.Play();
        } else {
            isMusicOn = false;
            mBgm.Pause();
        }
    }

    public void soundFX()
    {
        if (sfxToggle.isOn)
        {
            isSfxOn = true;
        } else {
            isSfxOn = false;
        }
    }
}
