using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox_controller : Living
{
    [SerializeField] GameObject Player;
    [SerializeField] float Fox_Speed;
    [SerializeField] float Fox_Rot_Speed;

    private bool Foxmove = true;

    [SerializeField] private int Combocount = 0;
    private float AttackTime = 0;
    private float maxComboDelay = 1.2f;


    private Rigidbody rigi;
    private Animator ani;
    private float h, v;  //방향


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
            transform.position += dir * Fox_Speed * Time.deltaTime;
            // 회전
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * Fox_Rot_Speed);
            ani.SetBool("PlayerWalk", true);
        }
        else
        {
            ani.SetBool("PlayerWalk", false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Foxmove = false;
            ani.SetTrigger("PlayerRoll");
            Player.transform.position = this.transform.position;
            Invoke("FoxmoveControll", 1f);

        }

    }

    private void Fox_Attack()
    {
        if (Time.time - AttackTime > maxComboDelay)
        {
            Combocount = 0;
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            Foxmove = false;
            Debug.Log("JJJJJ");
            AttackTime = Time.time;
            Combocount++;
            if (Combocount == 1)
            {
                ani.SetBool("Attack", true);
            }
            Combocount = Mathf.Clamp(Combocount, 0, 3);

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

    private void FoxmoveControll()
    {
        Foxmove = true;
    }

}
