using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target_Scanner : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float range;
    private string enemyTag = "TargetPoint";

    private void Start()
    {

    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            UpdateTarget();
            if (target == null)
            {
                return;
            }
            Vector3 dir = target.position - this.transform.position;
            dir.y = 0;
            this.transform.forward = dir.normalized;
        }


    }

    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
            if (nearestEnemy != null && shortestDistance <= range)
            {
                target = nearestEnemy.transform;
            }
            else
            {
                target = null;
            }
        }
    }    
}
