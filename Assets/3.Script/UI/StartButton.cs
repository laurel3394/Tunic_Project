using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void Map_one_Start()
    {
        AudioManager.instance.StopPlay(AudioManager.Bgm.Lobby);
        AudioManager.instance.PlaySFX(AudioManager.Sfx.Button);
        SceneManager.LoadScene("Map1");
        AudioManager.instance.PlayBGM(AudioManager.Bgm.Map1);
    }
    public void Minigame()
    {
        AudioManager.instance.StopPlay(AudioManager.Bgm.Lobby);
        AudioManager.instance.PlaySFX(AudioManager.Sfx.Button);
        SceneManager.LoadScene("Minigame");
        AudioManager.instance.PlayBGM(AudioManager.Bgm.MiniGame);
    }
    public void Minigame02()
    {
        AudioManager.instance.StopPlay(AudioManager.Bgm.Lobby);
        AudioManager.instance.PlaySFX(AudioManager.Sfx.Button);
        SceneManager.LoadScene("Minigame02");
        AudioManager.instance.PlayBGM(AudioManager.Bgm.MiniGame);
    }

}