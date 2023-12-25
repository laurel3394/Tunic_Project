using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Scavenger_Boss : Living
{
    [SerializeField] public float MonsterDamage;


    private void Awake()
    {
        Onenable();
    }
    private void Start()
    {
        StartCoroutine(Boss_Kick());
    }

    private IEnumerator Think_Action()                   //행동패턴
    {
        yield return new WaitForSeconds(0.1f);

        int RandomAction = Random.Range(0, 5);
        switch (RandomAction)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;

        }
    }

    private IEnumerator Boss_Kick()
    {
        while (true)
        {
            Vector3 dir = Fox_controller.instance.gameObject.transform.position - this.transform.position;
            dir.y = 0;
            this.transform.forward = dir.normalized;
            this.transform.position += transform.forward * Speed * Time.deltaTime;
            yield return null;

            float distance = Vector3.Distance(transform.position, Fox_controller.instance.transform.position);
            if (distance <=0.05)
            {
                Speed = 0f;
            }
            else
            {
                Speed = 0.075f;    //이거 수정 필요함 속도는 행동이 끝나고 초기화해주는걸로
            }
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
