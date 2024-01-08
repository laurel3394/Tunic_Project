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
    public AudioSource[] bgmPlayer;
    [Header("SFX")]
    public AudioClip[] sfxClip;
    public float sfxVolume;
    public AudioSource[] sfxPlayer;

    private int channalindex;
    private int BGMindex;


    public enum Bgm
    {
        Lobby,
        Map1,
        Scavenger,
        Ending
    }
    public enum Sfx
    {
        FoxHit,
        FoxSwing1,
        FoxSwing2,
        FoxSwing3,
        FoxWalk,
        FoxDie,
        Button
    }


    private void Awake()
    {
        Instance();
    }
    private void Start()
    {
        Init();
        PlayBGM(Bgm.Lobby);
    }
    //public void SFXPlay()
    //{
    //    GameObject sfx = new GameObject("Sound");
    //    AudioSource audioSource = sfx.AddComponent<AudioSource>()
    //}

    private void Update()
    {
        bgmPlayer[BGMindex].volume = bgmVolume;
        sfxPlayer[channalindex].volume = sfxVolume;
    }



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

    public void PlayBGM(Bgm bgm)
    {
        for (int i = 0; i < bgmPlayer.Length; i++)
        {
            int loopIndex = (i + BGMindex) % bgmPlayer.Length;

            if (bgmPlayer[loopIndex].isPlaying)
            {
                continue;
            }
            BGMindex = loopIndex;
            bgmPlayer[loopIndex].clip = bgmClip[(int)bgm];
            bgmPlayer[loopIndex].Play();
            break;
        }
    }
    public void PlaySFX(Sfx sfx)
    {
        for (int i = 0; i < sfxPlayer.Length; i++)
        {
            int loopIndex = (i + channalindex) % sfxPlayer.Length;

            if (sfxPlayer[loopIndex].isPlaying)
            {
                continue;
            }
            channalindex = loopIndex;
            sfxPlayer[loopIndex].clip = sfxClip[(int)sfx];
            sfxPlayer[loopIndex].Play();
            break;
        }
    }

    public void StopPlay(Bgm bgm)
    {
        bgmPlayer[(int)bgm].Stop();
    }
    public void StopPlay(Sfx sfx)
    {
        sfxPlayer[(int)sfx].Stop();
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
