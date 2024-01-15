using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Long_Big_Stick : Living
{
    [SerializeField] private float time;
    [SerializeField] private float sitckSpeed;
    private void Start()
    {
        StartCoroutine(FoxPusher());
    }
    private IEnumerator FoxPusher()
    {
        while (time <= 7f)
        {
            time += Time.deltaTime;
            transform.Translate(Vector3.forward *time * sitckSpeed);
            yield return null;
        }
        this.gameObject.SetActive(false);
        StickPool.instance.stickpool.Enqueue(gameObject);
    }
}
