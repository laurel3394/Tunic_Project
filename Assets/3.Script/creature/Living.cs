using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Living : MonoBehaviour
{
    [SerializeField] protected int currentHp;  //확인용
    [SerializeField] protected int currentSp;

    [Header("기본정보")]
    [SerializeField] protected int StartHp;
    [SerializeField] protected int StartSp;
    [SerializeField] protected float Speed;
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
