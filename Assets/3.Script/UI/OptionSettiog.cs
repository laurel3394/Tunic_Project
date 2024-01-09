using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionSettiog : MonoBehaviour
{
    [SerializeField] private GameObject Settingpage;
    [SerializeField] private GameObject start;
    [SerializeField] private GameObject setting;
    [SerializeField] private GameObject Exit;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            AudioManager.instance.PlaySFX(AudioManager.Sfx.Button);
            Settingpage.SetActive(false);
            start.SetActive(true);
            setting.SetActive(true);
            Exit.SetActive(true);
        }       
    }
    public void Escape()
    {
        AudioManager.instance.PlaySFX(AudioManager.Sfx.Button);
        Settingpage.SetActive(false);
        Time.timeScale = 1;
        if (start==null && setting == null && Exit == null)
        {
            return;
        }
        start.SetActive(true);
        setting.SetActive(true);
        Exit.SetActive(true);
    }
}
