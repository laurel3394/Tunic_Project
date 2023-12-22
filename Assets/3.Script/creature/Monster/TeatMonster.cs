using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeatMonster : Living
{
    [SerializeField] public float MonsterDamage;


    private void Awake()
    {
        Onenable();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("PlayerAttack") || other.gameObject.layer == LayerMask.NameToLayer("EnemyAttack"))
        {
            OnDamage(Fox_controller.instance.Damage, DieTime);
        }
    }


}