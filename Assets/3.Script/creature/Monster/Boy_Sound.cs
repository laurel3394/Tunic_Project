using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boy_Sound : MonoBehaviour
{
    private void Boy_Walk()
    {
        AudioManager.instance.PlaySFX(AudioManager.Sfx.FoxWalk);
    }
    private void Boy_Swing1()
    {
        AudioManager.instance.PlaySFX(AudioManager.Sfx.BeefBoy_Swing1);
    }
    private void Boy_Swing2()
    {
        AudioManager.instance.PlaySFX(AudioManager.Sfx.BeefBoy_Swing2);
    }
    private void Boy_WakeUP()
    {
        AudioManager.instance.PlaySFX(AudioManager.Sfx.Beef_freash);
    }
}
