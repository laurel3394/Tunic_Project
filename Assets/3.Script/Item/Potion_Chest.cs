using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion_Chest : MonoBehaviour
{
    private Animator ani;
    [SerializeField] private GameObject potion;

    private void Start()
    {
        ani = GetComponent<Animator>();
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Fox_controller.instance.action = true;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Vector3 dir = transform.position - Fox_controller.instance.transform.position;
                Fox_controller.instance.transform.forward = dir;
                dir = dir.normalized;
                Fox_controller.instance.Fox_OpenChest();
                ani.SetTrigger("Open");
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Fox_controller.instance.action = false;
        }
    }

    private void OpenSound()
    {
        AudioManager.instance.PlaySFX(AudioManager.Sfx.Chest);
    }

    private void ChestOpen()
    {
        
        Invoke("potionmaker", 0.1f);
    }
    private void potionmaker()
    {
        potion.SetActive(true);
        this.gameObject.SetActive(false);   
    }
}
