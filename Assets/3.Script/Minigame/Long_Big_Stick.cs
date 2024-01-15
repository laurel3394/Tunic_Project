using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Long_Big_Stick : Living
{
    [SerializeField] private float timmer;
    [SerializeField] private float sitckSpeed;
    //private void Start()
    //{
    //    StartCoroutine(FoxPusher());
    //}
    private void Start()
    {
        StartCoroutine(FoxPusher());
    }
    private IEnumerator FoxPusher()
    {
        while (timmer <= 7f)
        {
            timmer += Time.deltaTime;
            transform.Translate(Vector3.forward * timmer * sitckSpeed);
            yield return null;
        }
        timmer = 0f;
        this.gameObject.SetActive(false);
        StickPool.instance.stickpool.Enqueue(this.gameObject);
    }
    public void StartStick()
    {
        StartCoroutine(FoxPusher());
    }
}
