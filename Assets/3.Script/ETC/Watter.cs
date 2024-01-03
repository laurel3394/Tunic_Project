using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Fox_controller.instance.Speed = 1;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Fox_controller.instance.Speed = 2;

        }
    }
}
