using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Scavenger_Boss : Living
{
    public static int MonsterDamage;
    [SerializeField] public int checkDamage;
    [SerializeField] private bool BossMoveControll = true;


    private void Awake()
    {
        Onenable();
        ani = GetComponent<Animator>();
    }
    private void Start()
    {
        StartCoroutine(Boss_Slach());
    }
    private void Update()
    {
        checkDamage = MonsterDamage;
    }
    private IEnumerator Think_Action()                   //행동패턴
    {
        yield return new WaitForSeconds(0.2f);

        int RandomAction = Random.Range(0, 3);
        switch (RandomAction)
        {
            case 0:
                StartCoroutine(Boss_Kick());
                break;
            case 1:
                StartCoroutine(Boss_Punch());
                break;
            case 2:
                StartCoroutine(Boss_Slach());
                break;
            //case 3:
            //    StartCoroutine(Boss_Slach());
            //    break;
            //case 4:
            //    StartCoroutine(Boss_Slach());
            //    break;

        }
    }

    private IEnumerator Boss_Kick()
    {
        Boss_Move();
        yield return null;
        while (true)
        {
            MonsterDamage = 20;
            Boss_Move();
            yield return null;
        
            float distance = Vector3.Distance(transform.position, Fox_controller.instance.transform.position);
            if (distance <= 0.05f)
            {
                BossMoveControll = false;
                ani.SetTrigger("Boss_Kick");
                yield return new WaitForSeconds(1.533f);
                ani.ResetTrigger("Boss_Kick");
                Boss_NextAction();
            }
            else
            {
                BossMoveControll = true;
            }
        }
    }

    private IEnumerator Boss_Punch()
    {
        while (true)
        {
            MonsterDamage = 10;
            BossMoveControll = true;
            Boss_Move();
            yield return null;

            float distance = Vector3.Distance(transform.position, Fox_controller.instance.transform.position);
            if (distance >= 0.055f && distance <= 0.15f)
            {
                BossMoveControll = false;
                Boss_Move();
                ani.SetTrigger("Boss_Punch");
                yield return new WaitForSeconds(2.2f);
                ani.ResetTrigger("Boss_Punch");
                Boss_NextAction();
            }
            else if (distance <= 0.05f)
            {
                BossMoveControll = false;
                Boss_Move();
                ani.SetTrigger("Boss_BackStep");
                yield return new WaitForSeconds(1.05f);
                ani.ResetTrigger("Boss_BackStep");
                Boss_NextAction();
            }
            else
            {
                BossMoveControll = true;
            }
        }
    }

    private IEnumerator Boss_Slach()
    {
        while (true)
        {
            MonsterDamage = 15;
            Boss_Move();
            yield return null;
            float distance = Vector3.Distance(transform.position, Fox_controller.instance.transform.position);
            if (distance >= 0.08 && distance <= 0.15)
            {
                BossMoveControll = false;
                Boss_Move();
                ani.SetTrigger("Boss_Leap");
                yield return new WaitForSeconds(2.9f);
                ani.ResetTrigger("Boss_Leap");
                Boss_NextAction();
            }
            if (distance <= 0.07)
            {
                BossMoveControll = false;
                Boss_Move();
                ani.SetTrigger("Boss_Slash");
                yield return new WaitForSeconds(3.2f);
                ani.ResetTrigger("Boss_Slash");
                Boss_NextAction();
            }
            else
            {
                BossMoveControll = true;
            }
        }
    }
    private void Boss_NextAction()
    {
        BossMoveControll = true;
        StopAllCoroutines();
        StartCoroutine(Think_Action());
    }

    private void Boss_Move()
    {
        float distance = Vector3.Distance(transform.position, Fox_controller.instance.transform.position);
        if (distance <= 0.05f)
        {
            BossMoveControll = false;
            Vector3 dir = Fox_controller.instance.gameObject.transform.position - this.transform.position;
            dir.y = 0;
            this.transform.forward = dir.normalized;
        }
        if (distance >= 0.05f)
        {
            BossMoveControll = true;
        }
        if (BossMoveControll)
        {
            Vector3 dir = Fox_controller.instance.gameObject.transform.position - this.transform.position;
            dir.y = 0;
            this.transform.forward = dir.normalized;
            this.transform.position += transform.forward * Speed * Time.deltaTime;
            ani.SetBool("Boss_Run", true);
        }
        else if (!BossMoveControll)
        {
            ani.SetBool("Boss_Run", false);
        }
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("PlayerAttack") || other.gameObject.layer == LayerMask.NameToLayer("EnemyAttack"))
        {
            OnDamage(Fox_controller.instance.Damage, DieTime);
        }
    }
}
