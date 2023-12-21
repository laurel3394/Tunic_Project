using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Living : MonoBehaviour
{
    protected int currentHp;

    [Header("기본정보")]
    [SerializeField] protected int StartHp;
    public bool isDead { get; protected set; }

    protected virtual void Onenable()
    {
        isDead = false;
        currentHp = StartHp;
    }

    public virtual void OnDamage(int Damage)
    {
        currentHp -= Damage;
        if (currentHp <= 0 && !isDead)
        {
            Die();
        }
    }
    public virtual void Die()
    {
        isDead = true;
    }


}
