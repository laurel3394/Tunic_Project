using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack_Parry : MonoBehaviour
{
    private Animator ani;
    private void Start()
    {
        ani = GetComponentInParent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("PlayerParry"))
        {
            StartCoroutine(Parry());
        }
        else
        {
            return;
        }
    }
    private IEnumerator Parry()
    {
        ani.SetTrigger("Parry");
        yield return new WaitForSeconds(1.28f);
    }
}
