using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//���� ������ 
//�ִϸ��̼� ���?
//���ݷ�
//����?

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
