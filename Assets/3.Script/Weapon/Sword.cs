using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    protected override void InitSetting()
    {
        data.Damage = 10f;
    }

    protected override void Using()
    {

    }
}
