using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Living : MonoBehaviour
{
    public int MonsterDamage;
    [SerializeField] public float currentHp;  //Ȯ�ο�
    [SerializeField] protected float currentSp;

    [Header("�⺻����")]
    [SerializeField] protected float StartHp;
    [SerializeField] protected float StartSp;
    [SerializeField] public float Speed;
    [SerializeField] protected float DieTime;

    protected Animator ani;
    public bool isDead { get; protected set; }

    protected virtual void Onenable()
    {
        isDead = false;
        currentHp = StartHp;
        currentSp = StartSp;
    }

    public virtual void OnDamage(int Damage, float DieTime)
    {
        currentHp -= Damage;
        if (currentHp <= 0 && !isDead)
        {
            Die(DieTime);
        }
    }
    public virtual void Die(float DieTime)
    {

        isDead = true;
        Destroy(gameObject,DieTime);
    }


}
