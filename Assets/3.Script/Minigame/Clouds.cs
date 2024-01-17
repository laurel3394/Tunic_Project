using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    [SerializeField] float Power;
    Renderer renderer;
    int count = 0;
    float jumptime = 1f;
    private CloudControll cloudControll;
    private void Awake()
    {
        cloudControll = GetComponentInParent<CloudControll>();
    }
    public void gamestart()
    {
        this.gameObject.SetActive(true);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Fox_controller.instance.Foxmove = false;
            StartCoroutine(Jumping());

        }
    }
    private IEnumerator Jumping()
    {
        float timmer = 0;
        while (timmer <= 2f)
        {
            timmer += Time.deltaTime;
            if (timmer >= jumptime)
            {
                count++;
                jumptime *= 0.5f;
                Fox_controller.instance.Foxmove = true;
                Fox_controller.instance.rigi.AddForce(Vector3.up * Power, ForceMode.VelocityChange);
                AudioManager.instance.PlaySFX(AudioManager.Sfx.Jump);
                this.gameObject.SetActive(false);
                cloudControll.StartCoroutine(cloudControll.MinigameHeaven());
            }
            yield return null;
        }
    }


}
