using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target_Scanner : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float range;
    private string enemyTag = "Enemy";

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









    //[SerializeField]private float ScanRange;
    //[SerializeField] private LayerMask targetLayer;
    //[SerializeField] private RaycastHit[] targets;
    //[SerializeField] private Transform nearestTarget;
    //
    //private void FixedUpdate()
    //{
    //    targets = Physics.SphereCastAll(transform.position, ScanRange, Vector3.zero, 0);
    //    nearestTarget = GetNearest();
    //}
    //
    //Transform GetNearest()
    //{
    //    Transform result = null;
    //    float diff = 100;
    //    foreach (RaycastHit target in targets)
    //    {
    //        Vector3 myPos = transform.position;
    //        Vector3 targetPos = target.transform.position;
    //        float curDiff = Vector3.Distance(myPos, targetPos);
    //
    //        if (curDiff < diff)
    //        {
    //            diff = curDiff;
    //            result = target.transform;
    //        }
    //    }
    //    return result;
    //}
}
