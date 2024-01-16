using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option_Button : MonoBehaviour
{
    [SerializeField] private GameObject Settingpage;
    [SerializeField] private GameObject start;
    [SerializeField] private GameObject setting;
    [SerializeField] private GameObject Exit;
    [SerializeField] private GameObject Mini1;
    [SerializeField] private GameObject Mini2;
    public void Option_Click()
    {
        AudioManager.instance.PlaySFX(AudioManager.Sfx.Button);
        Settingpage.SetActive(true);
        start.SetActive(false);
        setting.SetActive(false);
        Exit.SetActive(false);
        Mini1.SetActive(false);
        Mini2.SetActive(false);
    }
}