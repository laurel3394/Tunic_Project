using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox_controller : Living
{
    public static Fox_controller instance = null;
    [Header("플레이어 정보")]
    [SerializeField] private GameObject Sword;
    [SerializeField] private GameObject Wand;
    [SerializeField] private GameObject Beam;
    [SerializeField] private float Fox_Rot_Speed;
    [SerializeField] public int Damage;
    [SerializeField] private int SwordDamage;
    [SerializeField] private int WandDamage;

    private bool Foxmove = true;
    private bool FoxAttack = true;
    public bool FoxFocus = true;
    
    [Header("확인용")]
    [SerializeField] private int Combocount = 0;
    private float AttackTime = 0;
    private float maxComboDelay = 1.2f;
    private Rigidbody rigi;
    private float h, v;  //방향

    private void Awake()
    {
        Onenable();
        Fox_instance();
        Sword.SetActive(false);
        Wand.SetActive(false);
    }
    private void Start()
    {
       
        ani = GetComponent<Animator>();
        rigi = GetComponent<Rigidbody>();

    }
    private void Update()
    {
        Fox_Attack();
    }
    void FixedUpdate()
    {
        PlayerMove();
    }
    private void PlayerMove()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);

        if (!(h == 0 && v == 0) && Foxmove)
        {
            // 이동
            transform.position += dir * Speed * Time.deltaTime;
            // 회전
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * Fox_Rot_Speed);
            ani.SetBool("PlayerWalk", true);
        }
        else
        {
            ani.SetBool("PlayerWalk", false);
        }

    }

    private void Fox_Attack()
    {
        Vector3 dir = new Vector3(h, 0, v);

        if (Time.time - AttackTime > maxComboDelay)
        {
            Combocount = 0;
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            Damage = SwordDamage;
            Sword.SetActive(true);
            Wand.SetActive(false);
            Foxmove = false;
            AttackTime = Time.time;
            Combocount++;
            if (Combocount == 1)
            {
                ani.SetBool("Attack", true);
            }
            Combocount = Mathf.Clamp(Combocount, 0, 3);

        }
        if (Input.GetKeyDown(KeyCode.K)&& FoxAttack)
        {
            FoxAttack = false;
            Damage = WandDamage;
            Wand.SetActive(true);
            Sword.SetActive(false);
            Foxmove = false;
            ani.SetTrigger("WandAttack");
            Invoke("FoxmoveControll", 0.5f);
            Combocount = 0;
            return3();
            Invoke("FoxAttackControll", 2f);

        }
        if (Input.GetKeyDown(KeyCode.Space) && Foxmove)
        {
            FoxFocus = false;
            Foxmove = false;
            transform.rotation = Quaternion.LookRotation(dir);
            ani.SetTrigger("PlayerRoll");
            Invoke("FoxmoveControll", 0.5f);
        }

    }

        public void return1()
    {
        if (Combocount >=2)
        {
            Foxmove = false;
            ani.SetBool("Attack1", true);
        }
        else
        {
            ani.SetBool("Attack", false);
            Foxmove = true;
            Combocount = 0;
        }
    }
    public void return2()
    {
        if (Combocount >= 3)
        {
            Foxmove = false;
            ani.SetBool("Attack2", true);
        }
        else
        {
            ani.SetBool("Attack", false);
            ani.SetBool("Attack1", false);
            Foxmove = true;
            Combocount = 0;
        }
    }
    public void return3()
    {
        ani.SetBool("Attack", false);
        ani.SetBool("Attack1", false);
        ani.SetBool("Attack2", false);
        Foxmove = true;
        Combocount = 0;
    }

    private IEnumerator Fox_Wand_Beam()
    {
        Beam.SetActive(true);
        yield return new WaitForSeconds(0.03f);
        Beam.SetActive(false);
    }

    private void FoxAttackControll()
    {
        FoxAttack = true;
    }
    private void FoxmoveControll()
    {
        Foxmove = true;
        FoxFocus = true;
    }

    private void Fox_instance()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlayerRollMask()
    {
        gameObject.layer = LayerMask.NameToLayer("PlayerRoll");
    }
    public void PlayerMask()
    {
        gameObject.layer = LayerMask.NameToLayer("Player");
    }

    private void OnTriggerEnter(Collider other)   //맞는 애니메이션 적용
    {
        if (other.CompareTag("Boss_Attack"))
        {
            OnDamage(Scavenger_Boss.MonsterDamage, DieTime);
        }
        if (other.CompareTag("Boss_Hard_Attack"))
        {
            OnDamage(Scavenger_Boss.MonsterDamage, DieTime);
        }
    }
}
