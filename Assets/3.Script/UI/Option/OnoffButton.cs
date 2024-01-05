using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnoffButton : MonoBehaviour
{
    [SerializeField] private GameObject ON;
    [SerializeField] private GameObject OFF;

    public static bool onoff = true;

    public void On_Button()
    {
        onoff = true;
        ON.SetActive(false);
        OFF.SetActive(true);
        Debug.Log(onoff);

    }
    public void Off_Button()
    {
        onoff = false;
        ON.SetActive(true);
        OFF.SetActive(false);
        Debug.Log(onoff);
    }
}
