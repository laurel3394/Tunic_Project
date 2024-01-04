using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Scavenger_Boss : Living
{
    [SerializeField] public int checkDamage;
    [SerializeField] private bool BossMoveControll = true;
    [SerializeField] private bool BossMeleeAttack;
    [SerializeField] private float ThinkTime;
    [Header("보스 머티리얼")]
    [SerializeField] private GameObject BossBody;
    [SerializeField] private SkinnedMeshRenderer skinned;
    [SerializeField] private Material mat;
    [SerializeField] private Material mat2;
    [SerializeField] private Skybox skybox;
    [SerializeField] private Material Defultskybox;
    [Header("사소한 무기 빔")]
    [SerializeField] private GameObject weapon1;
    [SerializeField] private GameObject weapon2;
    [SerializeField] private GameObject weapon3;
    [SerializeField] private GameObject weapon4;
    [SerializeField] private GameObject Bullet;
    [SerializeField] private GameObject BulletSpawner;
    [SerializeField] private GameObject TargetPoint;
    [SerializeField] private TrailRenderer Beam1;
    [SerializeField] private TrailRenderer Beam2;
    [Header("UI")]
    [SerializeField] private Slider Boss_Hpslider;
    [SerializeField] private GameObject forntHp;
    [SerializeField] private GameObject EndHp;
    [SerializeField] private GameObject Boss_Hp;
    [SerializeField] private GameObject Boss_UI;
    [Header("포탈")]
    [SerializeField] GameObject Potal;

    private void Awake()
    {
        Onenable();
        ani = GetComponent<Animator>();
    }
    private void Start()
    {
        Boss_Hpslider.maxValue = currentHp;
        Boss_Hpslider.value = currentHp;
        StartCoroutine(Fox_Scanner());
    }
    private void Update()
    {
        checkDamage = MonsterDamage;
    }

    private IEnumerator Fox_Scanner()
    {
        while (true)
        {
           float distance = Vector3.Distance(transform.position, Fox_controller.instance.transform.position);
            if (distance <= 10f)
            {
                Boss_Hp.SetActive(true);
                Boss_UI.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                ani.SetTrigger("First");
                yield return new WaitForSeconds(1.040f);
                StartCoroutine(Think_Action());
                break;
            }
            yield return null;
        }
    }

    private IEnumerator Think_Action()                   //행동패턴
    {
        BossMoveControll = false;
        skinned.material = mat;
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
            if (distance <= 2.2f)
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
            MonsterDamage = 25;
            Boss_Move();
            yield return null;

            float distance = Vector3.Distance(transform.position, Fox_controller.instance.transform.position);
            if (distance >= 3 && distance <= 10f)
            {
                BossMoveControll = false;
                Boss_Move();
                ani.SetTrigger("Boss_Punch");
                yield return new WaitForSeconds(2.28f);
                ani.ResetTrigger("Boss_Punch");
                Boss_NextAction();
                break;
            }
            else if (distance <= 2.5f)
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
            MonsterDamage = 30;
            Boss_Move();
            yield return null;
            float distance = Vector3.Distance(transform.position, Fox_controller.instance.transform.position);
            if (distance >= 3f && distance <= 15)
            {
                BossMoveControll = false;
                Boss_Move();
                ani.SetTrigger("Boss_Leap");
                yield return new WaitForSeconds(2.8f);
                ani.ResetTrigger("Boss_Leap");
                Boss_NextAction();
                break;
            }
            else if (distance <= 2.5f)
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
            if (distance <= 2f)
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
            if (distance >= 5 && distance <= 15)
            {
                BossMoveControll = false;
                Boss_Move();
                ani.SetTrigger("Boss_Shoot");
                yield return new WaitForSeconds(1.44f);
                ani.ResetTrigger("Boss_Shoot");
                Boss_NextAction();
                break;
            }
            else if (distance <= 2.5f)
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

    private IEnumerator Boss_Hit()
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
    }
    private IEnumerator Boss_Bullet()
    {
        GameObject bullet = Instantiate(Bullet, BulletSpawner.transform.position,Bullet.transform.rotation);
        Destroy(bullet, 5);
        yield return null;
    }
    private void Boss_NextAction()
    {
        if (Fox_controller.instance.isDead)
        {
            return;
        }
        BossMoveControll = true;
        StopAllCoroutines();
        StartCoroutine(Think_Action());
    }

    private void Boss_Move()
    {
        Turnoff();
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
   
    private void Turnoff()
    {
        Beam1.GetComponent<TrailRenderer>();
        Beam1.emitting = false;
        Beam2.GetComponent<TrailRenderer>();
        Beam2.emitting = false;
    }
    private void TurnOn()
    {
        Beam1.GetComponent<TrailRenderer>();
        Beam1.emitting = true;
        Beam2.GetComponent<TrailRenderer>();
        Beam2.emitting = true;
    }
    private void BossUIcontroll()
    {
        Boss_Hp.SetActive(false);
        Boss_UI.SetActive(false);
    }

    private void BossDieEvent()               //이거 수정 필요
    {
        Time.timeScale = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("PlayerAttack"))
        {
            CameraControll.instance.OnShakeCamera(0.05f, 1f);
            StartCoroutine(Boss_Hit());
            OnDamage(Fox_controller.instance.Damage, DieTime);
            Boss_Hpslider.value = currentHp;
            forntHp.SetActive(false);
        }
        if (currentHp <=0)
        {
            EndHp.SetActive(false);
            weapon1.SetActive(false);
            weapon2.SetActive(false);
            weapon3.SetActive(false);
            weapon4.SetActive(false);
            Potal.SetActive(true);
            TargetPoint.tag = "Enemy";
            Boss_Layer();
            Time.timeScale = 0.5f;
            Invoke("BossDieEvent", 2f);                 //보스 죽고 슬로우 시간 
            ani.SetTrigger("Boss_Die");
            Invoke("BossUIcontroll", 3f);
            StopAllCoroutines();
        }
    }
    private void Boss_Layer()
    {
        gameObject.layer = LayerMask.NameToLayer("EnemyDie");
    }
}