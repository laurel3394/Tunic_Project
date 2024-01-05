using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;
    [Header("BGM")]
    public AudioClip[] bgmClip;
    public float bgmVolume;
    AudioSource[] bgmPlayer;
    [Header("SFX")]
    public AudioClip[] sfxClip;
    public float sfxVolume;
    AudioSource[] sfxPlayer;
    public enum Bgm
    {
        Lobby,
        Map1,
        Scavenger,
        Ending
    }
    public enum Sfx
    {

    }


    private void Awake()
    {
        Instance();
    }
    private void Start()
    {
        Init();
    }
    //public void SFXPlay()
    //{
    //    GameObject sfx = new GameObject("Sound");
    //    AudioSource audioSource = sfx.AddComponent<AudioSource>()
    //}





    private void Init()
    {
        //배경음 초기화
        GameObject bgmObj = new GameObject("BgmPlayer");
        bgmObj.transform.parent = transform;
        bgmPlayer = new AudioSource[bgmClip.Length];
        for (int i = 0; i < bgmPlayer.Length; i++)
        {
            bgmPlayer[i] = bgmObj.AddComponent<AudioSource>();
            bgmPlayer[i].playOnAwake = false;
            bgmPlayer[i].loop = true;
            bgmPlayer[i].volume = bgmVolume;
        }
    
        //효과음 초기화
    
        GameObject sfxObj = new GameObject("SfxPlayer");
        sfxObj.transform.parent = transform;
        sfxPlayer = new AudioSource[sfxClip.Length];
        for (int i = 0; i < sfxPlayer.Length; i++)
        {
            sfxPlayer[i] = sfxObj.AddComponent<AudioSource>();
            sfxPlayer[i].playOnAwake = false;
            sfxPlayer[i].loop = false;
            sfxPlayer[i].volume = bgmVolume;
        }
    }









    private void Instance()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
