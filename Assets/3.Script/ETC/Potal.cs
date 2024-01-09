using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potal : MonoBehaviour
{
    private Animator ani;
    [SerializeField] private GameObject Enemy1;
    [SerializeField] private GameObject Enemy2;
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
            if (distance <= 10f && Enemy1 == null && Enemy2 == null)
            {
                ani.SetTrigger("Open");
                break;
            }
            yield return null;
        }
    }

    public void PotalOpen1()
    {
        AudioManager.instance.PlaySFX(AudioManager.Sfx.Potal_Open01);
    }
    public void PotalOpen2()
    {
        AudioManager.instance.PlaySFX(AudioManager.Sfx.Potal_Open02);
    }
}