using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resolution_Dropdown : MonoBehaviour
{
    FullScreenMode screenMode;
    public Dropdown dropdown;
    public Toggle fullscreenBtn;
    List<Resolution> resolutions = new List<Resolution>();

    [SerializeField] int resnum;
    private void Start()
    {
        InitUI();
    }
    private void InitUI()
    {
        for (int i = 0; i < Screen.resolutions.Length; i++)
        {
            if (Screen.resolutions[i].refreshRate == 60)
            {
                resolutions.Add(Screen.resolutions[i]);
            }
        }
        dropdown.options.Clear();

        int optionNum = 0;

        foreach (Resolution item in resolutions)
        {
            Dropdown.OptionData option = new Dropdown.OptionData();
            option.text = item.width + "x" + item.height + "x" + item.refreshRate + "hz";
            dropdown.options.Add(option);

            if (item.width == Screen.width && item.height == Screen.height )
            {
                dropdown.value = optionNum;
                optionNum++;
            }
            fullscreenBtn.isOn = Screen.fullScreenMode.Equals(FullScreenMode.FullScreenWindow)? true : false;
        }
        dropdown.RefreshShownValue();
    }
    public void FullScreen(bool isFull)
    {
        screenMode = isFull ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
    }

    public void OkBtnClick()
    {
        Screen.SetResolution(resolutions[resnum].width, resolutions[resnum].height, screenMode);
    }

    public void DropboxOption(int x)
    {
        resnum = x;
    }
}
