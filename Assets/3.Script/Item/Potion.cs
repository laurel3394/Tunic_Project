using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    [SerializeField] GameObject Slot1;
    [SerializeField] GameObject Slot2;
    [SerializeField] GameObject Slot3;

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
            dir.y = 0;
            this.transform.position += dir * 3 * Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (Fox_controller.instance.PotionCount+1)
            {
                case 1:
                    Slot1.SetActive(true);
                    break;
                case 2:
                    Slot2.SetActive(true);
                    break;
                case 3:
                    Slot3.SetActive(true);
                    break;
                default:
                    return;
            }
            AudioManager.instance.PlaySFX(AudioManager.Sfx.GetPotion);
            Fox_controller.instance.Potion.Enqueue(this.gameObject);
            Fox_controller.instance.PotionCount++;
            Destroy(gameObject);
        }
    }
}