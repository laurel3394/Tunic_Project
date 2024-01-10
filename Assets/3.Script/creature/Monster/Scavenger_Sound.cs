using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scavenger_Sound : MonoBehaviour
{
    private void Boss_Walk()
    {
        AudioManager.instance.PlaySFX(AudioManager.Sfx.FoxWalk);
    }
    private void Boss_JumpDown()
    {
        AudioManager.instance.PlaySFX(AudioManager.Sfx.Boss_JumpDown);
    }
    private void Boss_Ice()
    {
        AudioManager.instance.PlaySFX(AudioManager.Sfx.Boss_Ice);
    }
    private void Boss_FireBall()
    {
        AudioManager.instance.PlaySFX(AudioManager.Sfx.Boss_Fire);
    }
    private void Boss_Attack()
    {
        AudioManager.instance.PlaySFX(AudioManager.Sfx.Boss_Swing1);
    }
    private void Boss_Attack2()
    {
        AudioManager.instance.PlaySFX(AudioManager.Sfx.Boss_Swing2);
    }
    private void Boss_Hit()
    {
        AudioManager.instance.PlaySFX(AudioManager.Sfx.BeefBoy_Hit);
    }
    private void Boss_Skill()
    {
        AudioManager.instance.PlaySFX(AudioManager.Sfx.Boss_Skill);
    }
    private void Boss_Die()
    {
        AudioManager.instance.PlaySFX(AudioManager.Sfx.Boss_Die);
    }
    private void Boss_Parry()
    {
        AudioManager.instance.PlaySFX(AudioManager.Sfx.Fox_Parry);
    }
    private void Boss_Howling()
    {
        AudioManager.instance.PlaySFX(AudioManager.Sfx.Boss_Howling);
    }
}
