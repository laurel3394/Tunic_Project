using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Scavenger_Boss : Living
{
    public static int MonsterDamage;
    [SerializeField] public int checkDamage;
    [SerializeField] private bool BossMoveControll = true;
    private int ActionCount = 0;


    private void Awake()
    {
        Onenable();
        ani = GetComponent<Animator>();
    }
    private void Start()
    {
        StartCoroutine(Think_Action());
    }
    private void Update()
    {
        checkDamage = MonsterDamage;
    }
    private IEnumerator Think_Action()                   //행동패턴
    {
        yield return new WaitForSeconds(0.2f);

        int RandomAction = Random.Range(0, 5);
        int i = 0;
        switch (i)
        {
            case 0:
                StartCoroutine(Boss_Kick());
                break;
            //case 1:
            //    StartCoroutine(Boss_Punch());
            //    break;
            //case 2:
            //    StartCoroutine(Boss_Slach());
            //    break;
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
        while (true)
        {
            MonsterDamage = 20;
            Boss_Move();

            float distance = Vector3.Distance(transform.position, Fox_controller.instance.transform.position);
            if (distance <= 0.05f)
            {
                BossMoveControll = false;
                Boss_Move();
                ani.SetTrigger("Boss_Kick");
                yield return new WaitForSeconds(1.533f);
                ani.ResetTrigger("Boss_Kick");
                Boss_NextAction();
            }
            else
            {
                BossMoveControll = true;
                Boss_NextAction();
            }
        }
    }

    private IEnumerator Boss_Punch()
    {
        while (true)
        {
            BossMoveControll = true;
            Boss_Move();
            MonsterDamage = 10;

            float distance = Vector3.Distance(transform.position, Fox_controller.instance.transform.position);
            if (distance >= 0.055f && distance <= 0.15f && ActionCount == 0)
            {
                ActionCount = 1;
                BossMoveControll = false;
                Boss_Move();
                ani.SetTrigger("Boss_Punch");
                yield return new WaitForSeconds(2.2f);
                ani.ResetTrigger("Boss_Punch");
                Boss_NextAction();
            }
            else if (distance >= 0.05f && ActionCount == 0)
            {
                BossMoveControll = false;
                Boss_Move();
                ActionCount = 1;
                ani.SetTrigger("Boss_BackStep");
                yield return new WaitForSeconds(1.05f);
                ani.ResetTrigger("Boss_BackStep");
                ani.SetTrigger("Boss_Punch");
                yield return new WaitForSeconds(2.2f);
                ani.ResetTrigger("Boss_Punch");
                Boss_NextAction();
            }
            else
            {
                BossMoveControll = true;
                Boss_NextAction();
            }
        }
    }

    private IEnumerator Boss_Slach()
    {
        while (true)
        {
            MonsterDamage = 15;
            Boss_Move();

            float distance = Vector3.Distance(transform.position, Fox_controller.instance.transform.position);
            if (distance >= 0.08 && distance <= 0.15 && ActionCount == 0)
            {
                ActionCount = 1;
                BossMoveControll = false;
                Boss_Move();
                ani.SetTrigger("Boss_Leap");
                yield return new WaitForSeconds(2.8f);
                ani.ResetTrigger("Boss_Leap");
                StartCoroutine(Boss_Melee());
            }
            else
            {
                BossMoveControll = true;
                Boss_NextAction();
            }
        }
    }
    private void Boss_NextAction()
    {
        BossMoveControll = true;
        ActionCount = 0;
        StopAllCoroutines();
        StartCoroutine(Think_Action());
    }

    private void Boss_Move()
    {
        if (BossMoveControll)
        {
            Vector3 dir = Fox_controller.instance.gameObject.transform.position - this.transform.position;
            dir.y = 0;
            this.transform.forward = dir.normalized;
            this.transform.position += transform.forward * Speed * Time.deltaTime;
            ani.SetBool("Boss_Run",true);
        }
        else if (!BossMoveControll)
        {
            ani.SetBool("Boss_Run",false);
        }
    }
    private IEnumerator Boss_Melee()
    {
        int RandomAction = Random.Range(0, 2);
        switch (RandomAction)
        {
            case 0:
                ActionCount = 1;
                BossMoveControll = false;
                Boss_Move();
                ani.SetTrigger("Boss_Slash");
                yield return new WaitForSeconds(3.2f);
                ani.ResetTrigger("Boss_Slash");
                Boss_NextAction();
                break;
            case 1:
                ActionCount = 1;
                BossMoveControll = false;
                Boss_Move();
                ani.SetTrigger("Boss_BackStep");
                yield return new WaitForSeconds(1.2f);
                ani.ResetTrigger("Boss_BackStep");
                Boss_NextAction();
                break;
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
