using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox_Sound : MonoBehaviour
{
    private void Fox_Walk()
    {
        AudioManager.instance.PlaySFX(AudioManager.Sfx.FoxWalk);
    }
    private void Fox_Swing1()
    {
        AudioManager.instance.PlaySFX(AudioManager.Sfx.FoxSwing1);
    }
    private void Fox_Swing2()
    {
        AudioManager.instance.PlaySFX(AudioManager.Sfx.FoxSwing2);
    }
    private void Fox_Swing3()
    {
        AudioManager.instance.PlaySFX(AudioManager.Sfx.FoxSwing3);
    }
    private void Fox_Roll()
    {
        AudioManager.instance.PlaySFX(AudioManager.Sfx.Fox_Roll);
    }
    private void Fox_Beam()
    {
        AudioManager.instance.PlaySFX(AudioManager.Sfx.FoxWalk);
    }
    private void Fox_Heal()
    {
        AudioManager.instance.PlaySFX(AudioManager.Sfx.UsePotion);
    }
}
