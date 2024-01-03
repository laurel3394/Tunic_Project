using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    private void Update()
    {
        if (Fox_controller.instance.PotionCount >= 3)
        {
            return;
        }
        float distance = Vector3.Distance(transform.position, Fox_controller.instance.transform.position);
        if (distance <=2f)
        {
            Vector3 dir = Fox_controller.instance.gameObject.transform.position - this.transform.position;
            this.transform.position += dir * 3 * Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Fox_controller.instance.PotionCount>=3)
            {
                return;
            }
            Fox_controller.instance.Potion.Enqueue(this.gameObject);
            Fox_controller.instance.PotionCount++;
            Destroy(gameObject);
        }
    }
}