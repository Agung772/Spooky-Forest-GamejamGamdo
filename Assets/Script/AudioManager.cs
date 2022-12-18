using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public bool opening,nonAktifRandomAudio;
    public static AudioManager instance;
    public AudioSource audioSourceBacksound, audioSourceSfx, audioSourceMonster;
    public AudioClip jumpTanah, jumpRumah, ground, death, buttonUI, buttonP, tuasP, fallWater, projectile, pintu, duri, kunti, gundoruwo, portal;
    public AudioClip[] audioRandom;
    public float volumeBacksound, volumeSfx;
    public GameObject[] bsVol, sfxVol;

    

    private void Awake()
    {
        if (opening)
        {
            PlayerPrefs.SetFloat("VolBG", 2);
            PlayerPrefs.SetFloat("VolSfx", 2);
        }
        instance = this;
        volumeBacksound = PlayerPrefs.GetFloat("VolBG");
        volumeSfx = PlayerPrefs.GetFloat("VolSfx");

        audioSourceBacksound.volume = volumeBacksound / 5;
        audioSourceSfx.volume = volumeSfx / 5;
        if (audioSourceMonster != null) audioSourceMonster.volume = volumeSfx / 5;


        UpdateBSVol();
        UpdateSFXVol();
        if (!nonAktifRandomAudio)
        {
            InvokeRepeating("AudioRandom", 20, 20);
        }


    }
    void AudioRandom()
    {
        audioSourceBacksound.PlayOneShot(audioRandom[Random.Range(0, audioRandom.Length)]);
    }
    public void PlusAudioBacksound()
    {
        volumeBacksound += 1f;
        audioSourceBacksound.volume = volumeBacksound / 5;
        volumeBacksound = Mathf.Clamp(volumeBacksound, 0, 5);
        UpdateBSVol();
        SaveVol();
    }
    public void MinusAudioBacksound()
    {
        volumeBacksound -= 1f;
        audioSourceBacksound.volume = volumeBacksound / 5;
        volumeBacksound = Mathf.Clamp(volumeBacksound, 0, 5);
        UpdateBSVol();
        SaveVol();
    }


    public void PlusAudioSfx()
    {
        volumeSfx += 1f;
        audioSourceSfx.volume = volumeSfx / 5;
        volumeSfx = Mathf.Clamp(volumeSfx, 0, 5);
        if (audioSourceMonster != null) audioSourceMonster.volume = volumeSfx / 5;
        UpdateSFXVol();
        SaveVol();
    }
    public void MinusAudioSfx()
    {
        volumeSfx -= 1f;
        audioSourceSfx.volume = volumeSfx / 5;
        volumeSfx = Mathf.Clamp(volumeSfx, 0, 5);
        if (audioSourceMonster != null) audioSourceMonster.volume = volumeSfx / 5;
        UpdateSFXVol();
        SaveVol();
    }
    public void SaveVol()
    {
        PlayerPrefs.SetFloat("VolBG", volumeBacksound);
        PlayerPrefs.SetFloat("VolSfx", volumeSfx);
        SfxBuutonUI();
    }
    public void UpdateBSVol()
    {
        if (volumeBacksound == 0)
        {
            bsVol[0].SetActive(false);
            bsVol[1].SetActive(false);
            bsVol[2].SetActive(false);
            bsVol[3].SetActive(false);
            bsVol[4].SetActive(false);
        }
        else if (volumeBacksound == 1)
        {
            bsVol[0].SetActive(true);
            bsVol[1].SetActive(false);
            bsVol[2].SetActive(false);
            bsVol[3].SetActive(false);
            bsVol[4].SetActive(false);
        }
        else if (volumeBacksound == 2)
        {
            bsVol[0].SetActive(true);
            bsVol[1].SetActive(true);
            bsVol[2].SetActive(false);
            bsVol[3].SetActive(false);
            bsVol[4].SetActive(false);
        }
        else if (volumeBacksound == 3)
        {
            bsVol[0].SetActive(true);
            bsVol[1].SetActive(true);
            bsVol[2].SetActive(true);
            bsVol[3].SetActive(false);
            bsVol[4].SetActive(false);
        }
        else if (volumeBacksound == 4)
        {
            bsVol[0].SetActive(true);
            bsVol[1].SetActive(true);
            bsVol[2].SetActive(true);
            bsVol[3].SetActive(true);
            bsVol[4].SetActive(false);
        }
        else if (volumeBacksound == 5)
        {
            bsVol[0].SetActive(true);
            bsVol[1].SetActive(true);
            bsVol[2].SetActive(true);
            bsVol[3].SetActive(true);
            bsVol[4].SetActive(true);
        }
    }
    public void UpdateSFXVol()
    {
        if (volumeSfx == 0)
        {
            sfxVol[0].SetActive(false);
            sfxVol[1].SetActive(false);
            sfxVol[2].SetActive(false);
            sfxVol[3].SetActive(false);
            sfxVol[4].SetActive(false);
        }
        else if (volumeSfx == 1)
        {
            sfxVol[0].SetActive(true);
            sfxVol[1].SetActive(false);
            sfxVol[2].SetActive(false);
            sfxVol[3].SetActive(false);
            sfxVol[4].SetActive(false);
        }
        else if (volumeSfx == 2)
        {
            sfxVol[0].SetActive(true);
            sfxVol[1].SetActive(true);
            sfxVol[2].SetActive(false);
            sfxVol[3].SetActive(false);
            sfxVol[4].SetActive(false);
        }
        else if (volumeSfx == 3)
        {
            sfxVol[0].SetActive(true);
            sfxVol[1].SetActive(true);
            sfxVol[2].SetActive(true);
            sfxVol[3].SetActive(false);
            sfxVol[4].SetActive(false);
        }
        else if (volumeSfx == 4)
        {
            sfxVol[0].SetActive(true);
            sfxVol[1].SetActive(true);
            sfxVol[2].SetActive(true);
            sfxVol[3].SetActive(true);
            sfxVol[4].SetActive(false);
        }
        else if (volumeSfx == 5)
        {
            sfxVol[0].SetActive(true);
            sfxVol[1].SetActive(true);
            sfxVol[2].SetActive(true);
            sfxVol[3].SetActive(true);
            sfxVol[4].SetActive(true);
        }
    }

    public void SfxJumpTanah()
    {
        audioSourceSfx.PlayOneShot(jumpTanah);
    }
    public void SfxJumpRumah()
    {
        audioSourceSfx.PlayOneShot(jumpRumah);
    }
    public void SfxProjectile()
    {
        audioSourceSfx.PlayOneShot(projectile);
    }
    public void SfxDeath()
    {
        audioSourceSfx.PlayOneShot(death);
    }
    public void SfxBuutonUI()
    {
        audioSourceSfx.PlayOneShot(buttonUI);
    }
    public void SfxButtonP()
    {
        audioSourceSfx.PlayOneShot(buttonP);
    }
    public void SfxTuasP()
    {
        audioSourceSfx.PlayOneShot(tuasP);
    }
    public void SfxFallWater()
    {
        audioSourceSfx.PlayOneShot(fallWater);
    }
    public void SfxPintu()
    {
        audioSourceSfx.PlayOneShot(pintu);
    }
    public void SfxDuri()
    {
        audioSourceSfx.PlayOneShot(duri);
    }
    public void SfxKunti()
    {
        audioSourceSfx.PlayOneShot(kunti);
    }
    public void SfxGundoruwo()
    {
        audioSourceSfx.PlayOneShot(gundoruwo);
    }
    public void SfxPortal()
    {
        audioSourceSfx.PlayOneShot(portal);
    }
}
