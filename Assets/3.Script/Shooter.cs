using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject Boss;
    float time = 0;
    private void Start()
    {
        StartCoroutine(Shooooooooot());
    }
    private IEnumerator Shooooooooot()
    {
        while (Boss != null)
        {
            time += Time.deltaTime;
            if (time >= 10f)
            {
                time = 0f;
                Instantiate(Bullet,this.transform.position,this.transform.rotation);
            }
            yield return null;
        }
    }
}
