using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potal : MonoBehaviour
{
    private Animator ani;

    private void Start()
    {
        ani = GetComponent<Animator>();
        StartCoroutine(Potal_Open());
    }

    private IEnumerator Potal_Open()
    {
        while (true)
        {
            float distance = Vector3.Distance(transform.position, Fox_controller.instance.transform.position);
            if (distance <= 10f)
            {
                ani.SetTrigger("Open");
                break;
            }
            yield return null;
        }
    }
}