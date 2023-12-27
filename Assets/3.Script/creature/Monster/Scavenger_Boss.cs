using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Scavenger_Boss : Living
{
    public static int MonsterDamage;
    [SerializeField] public int checkDamage;
    [SerializeField] private bool BossMoveControll = true;
    [SerializeField] private bool BossMeleeAttack;
    [SerializeField] private float ThinkTime;


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
        BossMoveControll = false;
        Boss_Move();
        yield return new WaitForSeconds(ThinkTime);
        BossMoveControll = true;
        Boss_Move();
        int RandomAction = Random.Range(0, 5);
        switch (RandomAction)
        {
            case 0:
                StartCoroutine(Boss_Kick());
                break;
            case 1:
                StartCoroutine(Boss_Punch());
                break;
            case 2:
                StartCoroutine(Boss_Slash());
                break;
            case 3:
                StartCoroutine(Boss_Leap());
                break;
            case 4:
                StartCoroutine(Boss_Shoot());
                break;

        }
    }

    private IEnumerator Boss_Kick()
    {
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
                break;
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
            Boss_Move();
            yield return null;

            float distance = Vector3.Distance(transform.position, Fox_controller.instance.transform.position);
            if (distance >= 0.055 && distance <= 0.15f)
            {
                BossMoveControll = false;
                Boss_Move();
                ani.SetTrigger("Boss_Punch");
                yield return new WaitForSeconds(2.28f);
                ani.ResetTrigger("Boss_Punch");
                Boss_NextAction();
                break;
            }
            else if (distance <= 0.05f)
            {
                BossMoveControll = false;
                Boss_Move();
                ani.SetTrigger("Boss_BackStep");
                yield return new WaitForSeconds(1.2f);
                ani.ResetTrigger("Boss_BackStep");
                Boss_NextAction();
                break;
            }
            else
            {
                BossMoveControll = true;
            }
        }
    }

    private IEnumerator Boss_Leap()
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
                yield return new WaitForSeconds(2.8f);
                ani.ResetTrigger("Boss_Leap");
                Boss_NextAction();
                break;
            }
            else if (distance <= 0.05f)
            {
                BossMoveControll = false;
                Boss_Move();
                ani.SetTrigger("Boss_BackStep");
                yield return new WaitForSeconds(1.2f);
                ani.ResetTrigger("Boss_BackStep");
                Boss_NextAction();
                break;
            }
            else
            {
                BossMoveControll = true;
            }
        }
    }
    private IEnumerator Boss_Slash()
    {
        while (true)
        {
            MonsterDamage = 15;
            Boss_Move();
            yield return null;
            float distance = Vector3.Distance(transform.position, Fox_controller.instance.transform.position);
            if (distance <= 0.07)
            {
                BossMoveControll = false;
                Boss_Move();
                ani.SetTrigger("Boss_Slash");
                yield return new WaitForSeconds(3f);
                ani.ResetTrigger("Boss_Slash");
                Boss_NextAction();
                break;
            }
        }
    }
    private IEnumerator Boss_Shoot()
    {
        while (true)
        {
            MonsterDamage = 10;
            Boss_Move();
            yield return null;
            float distance = Vector3.Distance(transform.position, Fox_controller.instance.transform.position);
            if (distance >= 0.08 && distance <= 0.15)
            {
                BossMoveControll = false;
                Boss_Move();
                ani.SetTrigger("Boss_Shoot");
                yield return new WaitForSeconds(1.44f);
                ani.ResetTrigger("Boss_Shoot");
                Boss_NextAction();
                break;
            }
            else if (distance <= 0.05f)
            {
                BossMoveControll = false;
                Boss_Move();
                ani.SetTrigger("Boss_BackStep");
                yield return new WaitForSeconds(1.2f);
                ani.ResetTrigger("Boss_BackStep");
                ani.SetTrigger("Boss_Shoot");
                yield return new WaitForSeconds(1.44f);  //이건 모르겠다 너무 많이 쏘면 삭제
                ani.ResetTrigger("Boss_Shoot");
                Boss_NextAction();
                break;
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
        //float distance = Vector3.Distance(transform.position, Fox_controller.instance.transform.position);
        //if (distance <= 0.05f && !BossMeleeAttack)
        //{
        //    BossMoveControll = false;
        //    Vector3 dir = Fox_controller.instance.gameObject.transform.position - this.transform.position;
        //    dir.y = 0;
        //    this.transform.forward = dir.normalized;
        //}
        //if (distance >= 0.05f && !BossMeleeAttack)
        //{
        //    BossMoveControll = true;
        //}
        if (BossMoveControll)
        {
            ani.SetBool("Boss_Run", true);
            Vector3 dir = Fox_controller.instance.gameObject.transform.position - this.transform.position;
            dir.y = 0;
            this.transform.forward = dir.normalized;
            this.transform.position += transform.forward * Speed * Time.deltaTime;
        }
        else if (!BossMoveControll)
        {
            ani.SetBool("Boss_Run", false);
            return;
        }        
    }
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("PlayerAttack") || other.gameObject.layer == LayerMask.NameToLayer("EnemyAttack"))
        {
            OnDamage(Fox_controller.instance.Damage, DieTime);
        }
        if (currentHp <=0)
        {
            Boss_Layer();
            ani.SetBool("Boss_Die",true );
            StopAllCoroutines();
        }
    }
    private void Boss_Layer()
    {
        gameObject.layer = LayerMask.NameToLayer("EnemyDie");
    }
}
