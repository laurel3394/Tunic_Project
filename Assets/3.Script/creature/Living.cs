using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Living : MonoBehaviour
{
    [SerializeField] protected int currentHp;  //Ȯ�ο�

    [Header("�⺻����")]
    [SerializeField] protected int StartHp;
    [SerializeField] protected float Speed;
    [SerializeField] protected float DieTime;
    public bool isDead { get; protected set; }

    protected virtual void Onenable()
    {
        isDead = false;
        currentHp = StartHp;
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
