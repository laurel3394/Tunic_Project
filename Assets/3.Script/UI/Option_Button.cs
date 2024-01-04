using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option_Button : MonoBehaviour
{
    [SerializeField] private GameObject Settingpage;
    [SerializeField] private GameObject start;
    [SerializeField] private GameObject setting;
    [SerializeField] private GameObject Exit;
    public void Option_Click()
    {
        Settingpage.SetActive(true);
        start.SetActive(false);
        setting.SetActive(false);
        Exit.SetActive(false);
    }
}