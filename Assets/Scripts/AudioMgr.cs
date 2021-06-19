using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMgr : MonoBehaviour
{
    public static AudioMgr instance;
    public AudioSource[] sfx;
    public AudioSource bgm;
    public AudioSource bgm2;

    public bool isbgm2Playing;
    public enum MUSIC
    {
        BGM = 0,
        GRYRO_BROKEN,
        FIRE,
        SOLDIER_HURT,
        BUTTON_CLICK,
        PLAYER_DEAD,
        OH_NO
    }

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayBMG()
    {
        bgm.Play();
    }
    public void PlayBMG2()
    {
        bgm2.Play();
    }

    public void pauseBMG2()
    {
        bgm2.Pause();
    }
    public void playSfx(MUSIC sfxName)
    {
        switch(sfxName)
        {
            case MUSIC.FIRE:
                sfx[0].Play();
                break;
            case MUSIC.GRYRO_BROKEN:
                sfx[1].Play();
                break;
            case MUSIC.SOLDIER_HURT:
                sfx[2].Play();
                break;
            case MUSIC.BUTTON_CLICK:
                sfx[3].Play();
                break;
            case MUSIC.PLAYER_DEAD:
                sfx[4].Play();
                break;
            case MUSIC.OH_NO:
                sfx[5].Play();
                break;
        }
    }

    public void pauseSfx(MUSIC sfxName)
    {
        switch (sfxName)
        {
            case MUSIC.FIRE:
                sfx[0].Pause();
                break;
            case MUSIC.GRYRO_BROKEN:
                sfx[1].Pause();
                break;
            case MUSIC.SOLDIER_HURT:
                sfx[2].Pause();
                break;
            case MUSIC.BUTTON_CLICK:
                sfx[3].Pause();
                break;
            case MUSIC.PLAYER_DEAD:
                sfx[4].Pause();
                break;
            case MUSIC.OH_NO:
                sfx[5].Pause();
                break;
        }
    }

    
}
