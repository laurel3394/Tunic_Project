using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_BigStick : MonoBehaviour
{
    [SerializeField] private float timmer;
    [SerializeField] private float Maxtime;

    [SerializeField] private GameObject Pos1;
    [SerializeField] private GameObject Pos2;

    private void Start()
    {
        StartCoroutine(Kill_Fox());
    }
    private IEnumerator Kill_Fox()
    {
        while (!Fox_controller.instance.isDead)
        {
            timmer += Time.deltaTime;
            if (timmer >= Maxtime)
            {
                timmer = 0f;
                Maxtime = Random.Range(3f, 10f);
                int num = Random.Range(0, 2);
                switch (num)
                {
                    case 0:
                        GameObject Pos1_stick = StickPool.instance.stickpool.Dequeue();
                        Pos1_stick.transform.position = Pos1.transform.position;
                        Pos1_stick.transform.rotation = Pos1.transform.rotation;
                        Pos1_stick.SetActive(true);
                        break;
                    case 1:
                        GameObject Pos2_stick = StickPool.instance.stickpool.Dequeue();
                        Pos2_stick.transform.position = Pos2.transform.position;
                        Pos2_stick.transform.rotation = Pos2.transform.rotation;
                        Pos2_stick.SetActive(true);
                        break;
                    default:
                        break;
                }
            }
            yield return null;
        }
    }
}
