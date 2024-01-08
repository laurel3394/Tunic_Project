using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameOption : MonoBehaviour
{
    [SerializeField] private GameObject Settingpage;
    private bool SetAct = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SetAct)
        {
            AudioManager.instance.PlaySFX(AudioManager.Sfx.Button);
            SetAct = false;
            Settingpage.SetActive(false);
            Time.timeScale = 1f;

        }
        else if(Input.GetKeyDown(KeyCode.Escape) && !SetAct)
        {
            AudioManager.instance.PlaySFX(AudioManager.Sfx.Button);
            SetAct = true;
            Settingpage.SetActive(true);
            Time.timeScale = 0f;
        }
    }






}
