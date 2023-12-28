using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Shooter : MonoBehaviour
{
    [SerializeField] private float Bullet_Speed;
    void Start()
    {
        Vector3 dir = Fox_controller.instance.transform.position - transform.position;
        dir.y = 0;
        dir = dir.normalized;
        GetComponent<Rigidbody>().AddForce(dir * Bullet_Speed * Time.deltaTime, ForceMode.Impulse);
    }

}
