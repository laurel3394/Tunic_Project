using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeefBoy_Shield : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("PlayerAttack")|| other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            BeefBoy.Shield_Damage = 15;
            StopCoroutine(Shield());
            StartCoroutine(Shield());
        }
    }
    private IEnumerator Shield()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        BeefBoy.Shield_Damage = 0;
    }
}
