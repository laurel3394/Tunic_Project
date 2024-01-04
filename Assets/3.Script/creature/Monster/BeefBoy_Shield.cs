using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeefBoy_Shield : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("PlayerAttack"))
        {
            BeefBoy.Shield_Damage = 15;
            StopCoroutine(Shield());
            StartCoroutine(Shield());
        }
    }
    private IEnumerator Shield()
    {
        yield return new WaitForSecondsRealtime(2f);
        BeefBoy.Shield_Damage = 0;
    }
}
