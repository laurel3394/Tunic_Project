using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeefBoy : Living
{
    [SerializeField] public int checkDamage;
    [SerializeField] private bool EnemyMoveControll = true;
    [SerializeField] private bool EnemyMeleeAttack;
    [SerializeField] private float ThinkTime;
    [SerializeField] public static int Shield_Damage;
    [Header("머티리얼")]
    [SerializeField] private SkinnedMeshRenderer skinned;
    [SerializeField] private Material mat;
    [SerializeField] private Material mat2;
    private void Awake()
    {
        Onenable();
        ani = GetComponent<Animator>();
    }
    private void Start()
    {
        StartCoroutine(Fox_Scanner());
    }
    private IEnumerator Fox_Scanner()
    {
        ani.SetTrigger("BeefSleep");
        while (true)
        {
            float distance = Vector3.Distance(transform.position, Fox_controller.instance.transform.position);
            if (distance <= 8f)
            {
                ani.SetTrigger("BeefWakeUp");
                yield return new WaitForSeconds(1.040f);
                StartCoroutine(Think_Action());
                break;
            }
            yield return null;
        }
    }






    private void Enemy_NextAction()
    {
        if (Fox_controller.instance.isDead)
        {
            return;
        }
        EnemyMoveControll = true;
        StopAllCoroutines();
        StartCoroutine(Think_Action());
    }

    private IEnumerator Think_Action()                   //행동패턴
    {
        EnemyMoveControll = false;
        skinned.material = mat;
        Enemy_Move();
        yield return new WaitForSeconds(ThinkTime);
        EnemyMoveControll = true;
        Enemy_Move();
        int RandomAction = Random.Range(0, 2);
        switch (RandomAction)
        {
            case 0:
                StartCoroutine(Enemy_Attack());
                break;
            case 1:
                StartCoroutine(Enemy_Swing());
                break;
        }
    }

    private IEnumerator Enemy_Swing()
    {
        while (true)
        {
            MonsterDamage = 20;
            Enemy_Move();
            yield return null;

            float distance = Vector3.Distance(transform.position, Fox_controller.instance.transform.position);
            if (distance <= 4f)
            {
                EnemyMoveControll = false;
                ani.SetTrigger("BeefSwing");
                yield return new WaitForSeconds(2.208f);
                ani.ResetTrigger("BeefSwing");
                Enemy_NextAction();
                break;
            }
            else
            {
                EnemyMoveControll = true;
            }
        }

    }

    private IEnumerator Enemy_Attack()
    {
        while (true)
        {
            MonsterDamage = 20;
            Enemy_Move();
            yield return null;

            float distance = Vector3.Distance(transform.position, Fox_controller.instance.transform.position);
            if (distance <= 4f)
            {
                EnemyMoveControll = false;
                ani.SetTrigger("BeefAttack");
                yield return new WaitForSeconds(1.625f);
                ani.ResetTrigger("BeefAttack");
                Enemy_NextAction();
                break;
            }
            else
            {
                EnemyMoveControll = true;
            }
        }
    }


    private void Enemy_Move()
    {
        if (EnemyMoveControll)
        {
            ani.SetBool("BeefWalk", true);
            Vector3 dir = Fox_controller.instance.gameObject.transform.position - this.transform.position;
            dir.y = 0;
            this.transform.forward = dir.normalized;
            this.transform.position += transform.forward * Speed * Time.deltaTime;
        }
        else if (!EnemyMoveControll)
        {
            ani.SetBool("BeefWalk", false);
            return;
        }
    }

    private IEnumerator Beef_Hit()
    {
        for (int i = 0; i < 3; i++)
        {
            skinned.material = mat;
            yield return new WaitForSeconds(0.05f);
            skinned.material = mat2;
            yield return new WaitForSeconds(0.05f);
            skinned.material = mat;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.86f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("PlayerAttack"))
        {
            CameraControll.instance.OnShakeCamera(0.01f, 1f);
            OnDamage(Fox_controller.instance.Damage - Shield_Damage, DieTime);
            if (currentHp <= 0)
            {
                skinned.material = mat;
                Boss_Layer();
                ani.SetTrigger("RottenMeat");
                StopAllCoroutines();
                return;
            }
            ani.SetTrigger("Schnitzel");
            StartCoroutine(Beef_Hit());
        }
    }
    private void Boss_Layer()
    {
        gameObject.layer = LayerMask.NameToLayer("EnemyDie");
    }

}   