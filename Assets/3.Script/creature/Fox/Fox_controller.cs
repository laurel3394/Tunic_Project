using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fox_controller : Living
{
    public static Fox_controller instance = null;
    [Header("플레이어 정보")]
    [SerializeField] private GameObject Sword;
    [SerializeField] private GameObject Wand;
    [SerializeField] private GameObject HandPotion;
    [SerializeField] private GameObject Beam;
    [SerializeField] private GameObject Hair;
    [SerializeField] private float Fox_Rot_Speed;
    [SerializeField] private float Fox_SPrecovery_Speed;
    [SerializeField] public int Damage;
    [SerializeField] private int SwordDamage;
    [SerializeField] private int WandDamage;
    [SerializeField] private int Sp_Roll;
    private int DeadCount=0;
    [Header("머티리얼")]
    [SerializeField] private GameObject FoxBody;
    [SerializeField] private SkinnedMeshRenderer skinned;
    [SerializeField] public Material mat;
    [SerializeField] public Material mat2;
    [SerializeField] public Material NightMat;
    [SerializeField] private Skybox skybox;
    private bool Foxmove = true;
    private bool FoxAttack = true;
    public bool FoxFocus = true;
    public bool FoxExhausted = false;
    public bool action = false;
    [Header("확인용")]
    [SerializeField] private int Combocount = 0;
    private float AttackTime = 0;
    private float maxComboDelay = 1.2f;
    private Rigidbody rigi;
    private float h, v;  //방향

    [Header("UI")]
    [SerializeField] private Slider HPslider;
    [SerializeField] private Slider SPslider;
    [SerializeField] private GameObject SPlight;
    [SerializeField] GameObject Potion_Slot1;
    [SerializeField] GameObject Potion_Slot2;
    [SerializeField] GameObject Potion_Slot3;

    [Header("Item")]
    public Queue<GameObject> Potion = new Queue<GameObject>();
    [SerializeField] public int PotionCount = 0;

    private void Awake()
    {
        Onenable();
        Fox_instance();
        Sword.SetActive(false);
        Wand.SetActive(false);
    }
    private void Start()
    {
        HPslider.maxValue= currentHp;
        SPslider.maxValue = currentSp;
        HPslider.value = currentHp;
        SPslider.value = currentSp;
        ani = GetComponent<Animator>();
        rigi = GetComponent<Rigidbody>();
        Potion_Slot1.SetActive(false);
        Potion_Slot2.SetActive(false);
        Potion_Slot3.SetActive(false);

    }
    private void Update()
    {
        if (currentSp<=0)
        {
            currentSp = 1f;
            Sp_Roll = 60;
            Fox_SPrecovery_Speed = 7f;
            FoxExhausted = true;
            SPlight.SetActive(true);
        }
        currentSp += Fox_SPrecovery_Speed * Time.deltaTime;
        if (currentSp >=StartSp)
        {
            currentSp = StartSp;
            Sp_Roll = 30;
            Fox_SPrecovery_Speed = 13f;
            FoxExhausted = false;
            SPlight.SetActive(false);
        }
        SPslider.value = currentSp;
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
        if (!(h == 0 && v == 0) && Foxmove && !isDead)
        {
            // 이동
            transform.position += dir * Speed * Time.deltaTime;
            // 회전
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * Fox_Rot_Speed);
            ani.SetBool("PlayerWalk", true);
            //if (Foxmove&& !AudioManager.instance.sfxPlayer[(int)AudioManager.Sfx.FoxWalk].isPlaying)
            //{
            //    AudioManager.instance.PlaySFX(AudioManager.Sfx.FoxWalk);
            //}
        }
        else
        {
            ani.SetBool("PlayerWalk", false);
            //AudioManager.instance.StopPlay(AudioManager.Sfx.FoxWalk);
        }

    }

    private void Fox_Attack()
    {
        Vector3 dir = new Vector3(h, 0, v);

        if (Time.time - AttackTime > maxComboDelay)
        {
            Combocount = 0;
        }

        if (Input.GetKeyDown(KeyCode.J) && !isDead)
        {
            Damage = SwordDamage;
            Sword.SetActive(true);
            Wand.SetActive(false);
            HandPotion.SetActive(false);
            Foxmove = false;
            AttackTime = Time.time;
            Combocount++;
            if (Combocount == 1)
            {
                ani.SetBool("Attack", true);
            }
            Combocount = Mathf.Clamp(Combocount, 0, 3);

        }
        if (Input.GetKeyDown(KeyCode.K)&& FoxAttack && !isDead && !FoxExhausted)
        {
            FoxAttack = false;
            Damage = WandDamage;
            FoxSp(45);
            Wand.SetActive(true);
            Sword.SetActive(false);
            HandPotion.SetActive(false);
            Foxmove = false;
            AudioManager.instance.PlaySFX(AudioManager.Sfx.Fox_Beam);
            ani.SetTrigger("WandAttack");
            Invoke("FoxmoveControll", 0.2f);
            Combocount = 0;
            return3();
            Invoke("FoxAttackControll", 2f);

        }
        if (Input.GetKeyDown(KeyCode.L) && FoxAttack && !isDead && !FoxExhausted)
        {
            FoxAttack = false;
            FoxSp(20);
            Foxmove = false;
            ani.SetTrigger("PlayerParry");
            Invoke("FoxmoveControll", 1.2f);
            Invoke("FoxAttackControll", 1.2f);

        }


        if (Input.GetKeyDown(KeyCode.Space) && Foxmove &&!action && !isDead)
        {
            if (currentSp < Sp_Roll)
            {
                return;
            }
            FoxSp(Sp_Roll);
            FoxFocus = false;
            Foxmove = false;
            transform.rotation = Quaternion.LookRotation(dir);
            ani.SetTrigger("PlayerRoll");
            Invoke("FoxmoveControll", 0.833f);
        }
        if (Input.GetKeyDown(KeyCode.P) && Foxmove && !isDead)
        {
            if (PotionCount <=0 || currentHp == StartHp)
            {
                return;
            }
            PotionCount--;
            switch (PotionCount)
            {
                case 1:
                    Potion_Slot2.SetActive(false);
                    Potion_Slot3.SetActive(false);
                    break;
                case 2:
                    Potion_Slot3.SetActive(false);
                    break;
                default:
                    Potion_Slot1.SetActive(false);
                    Potion_Slot2.SetActive(false);
                    Potion_Slot3.SetActive(false);
                    break;
            }
            Potion.Dequeue();
            FoxAttack = false;
            Foxmove = false;
            HandPotion.SetActive(true);
            Sword.SetActive(false);
            Wand.SetActive(false);
            ani.SetTrigger("PlayerEat");
            Invoke("FoxmoveControll", 1.55f);
            Invoke("FoxAttackControll", 1.55f);
            currentHp += 20f;
            HPslider.value = currentHp;
            if (currentHp >= StartHp)
            {
                currentHp = StartHp;
            }
        }

    }

    private IEnumerator PlayerHit()
    {
        FoxFocus = false;
        Foxmove = false;
        StartCoroutine(Fox_Hit());
        ani.SetTrigger("PlayerHurt");
        yield return new WaitForSeconds(0.8f);
        FoxFocus = true;
        Foxmove = true;
        ani.ResetTrigger("PlayerHurt");
    }
    private IEnumerator PlayerHardHIt()
    {
        FoxFocus = false;
        Foxmove = false;
        StartCoroutine(Fox_Hit());
        ani.SetTrigger("Playerstagger");
        yield return new WaitForSeconds(2f);               //0.750f
        FoxFocus = true;
        Foxmove = true;
        ani.ResetTrigger("Playerstagger");

    }
    private IEnumerator Fox_Hit()
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
    public void FoxNight()
    {
        Hair.GetComponentInChildren<SkinnedMeshRenderer>().material = mat;
        skinned.material = mat;
    }
    private void FoxSp(int Sp)
    {
        currentSp -= Sp;
        SPslider.value = currentSp;
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
        yield return new WaitForSeconds(0.035f);
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

    public void Fox_OpenChest()
    {
        ani.SetTrigger("PlayerOpen");
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
        if (other.CompareTag("Boss_Attack")&&this.gameObject.layer == LayerMask.NameToLayer("Player") && currentHp > 0)
        {
            AudioManager.instance.PlaySFX(AudioManager.Sfx.FoxHit);
            Combocount = 0;
            ani.SetBool("Attack", false);
            ani.SetBool("Attack1", false);
            ani.SetBool("Attack2", false);
            StartCoroutine(PlayerHit());
            CameraControll.instance.OnShakeCamera(0.1f, 1f);
            OnDamage(other.GetComponentInParent<Living>().MonsterDamage, DieTime);
            HPslider.value = currentHp;
            SPslider.value = currentSp;
        }
        if (other.CompareTag("Boss_Hard_Attack") && this.gameObject.layer == LayerMask.NameToLayer("Player") && currentHp > 0)
        {
            AudioManager.instance.PlaySFX(AudioManager.Sfx.FoxHit);
            Vector3 dir = other.transform.position - this.transform.position;
            dir.y = 0;
            this.transform.forward = dir.normalized;
            Combocount = 0;
            ani.SetBool("Attack", false);
            ani.SetBool("Attack1", false);
            ani.SetBool("Attack2", false);
            StartCoroutine(PlayerHardHIt());
            CameraControll.instance.OnShakeCamera(0.1f, 2.5f);
            OnDamage(other.GetComponentInParent<Living>().MonsterDamage, DieTime);
            HPslider.value = currentHp;
            SPslider.value = currentSp;
        }
        if (other.CompareTag("Boss_Bullet") && this.gameObject.layer == LayerMask.NameToLayer("Player")&& currentHp > 0)
        {
            AudioManager.instance.PlaySFX(AudioManager.Sfx.FoxHit);
            Combocount = 0;
            ani.SetBool("Attack", false);
            ani.SetBool("Attack1", false);
            ani.SetBool("Attack2", false);
            StartCoroutine(PlayerHit());
            Invoke("FoxmoveControll", 1f);
            CameraControll.instance.OnShakeCamera(0.1f, 1f);
            OnDamage(20, DieTime);
            HPslider.value = currentHp;
            SPslider.value = currentSp;
        }
        if (currentHp <= 0 && DeadCount == 0)
        {
            AudioManager.instance.PlaySFX(AudioManager.Sfx.FoxDie);
            DeadCount++;
            PlayerRollMask();
            ani.SetTrigger("Fox_Die");
            PlayerInfo.instance.Fade(0.3f);
            Invoke("DieFade", 3.6f);
            return;
        }
    }
    private void DieFade()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }

}