using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject Boss;
    [SerializeField] public GameObject target;
    [SerializeField] private float time;
    [SerializeField] private float shoottime;
    private void Start()
    {
        StartCoroutine(Shooooooooot());
    }
    private IEnumerator Shooooooooot()
    {
        while (Boss.layer != LayerMask.NameToLayer("EnemyDie"))
        {
            time += Time.deltaTime;
            if (time >= 1.5f)
            {
                target.SetActive(false);
            }
            if (time >= shoottime)
            {
                AudioManager.instance.PlaySFX(AudioManager.Sfx.CannonShoot);
                targetOn();
                time = 0f;
                Instantiate(Bullet,this.transform.position,this.transform.rotation);
            }
            yield return null;
        }   
    }
    private void targetOn()
    {
        target.transform.position = Fox_controller.instance.transform.position;
        target.SetActive(true);
    }
}
