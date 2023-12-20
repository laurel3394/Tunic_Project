using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//무기 공통점 
//애니메이션 출력?
//공격력
//옵젝?

public struct Data
{
    public float Damage;
    public GameObject weapon;
}

public abstract class Weapon : MonoBehaviour
{
    public Data data;

    protected abstract void InitSetting();

    protected abstract void Using();



}
