using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public string bulletName = "shell";
    public GameObject enemy;
    public GameObject Bullet;
    public Transform firePos;

    public float moveSpeed;
    public float jumpPower;

    private Animator animator;
    Vector3 originPos;
    const int countOfDamageAnimations = 3;
    int lastDamageAnimation = -1;

    public GameObject objectToVibrate;
    private Vibration vibration;

    public GameObject WayPoint0;
    public GameObject WayPoint1;
    public float MoveSpeed = 3.0f;
    public float RotationSpeed = 2.0f;
    bool isWayPoint = false;
    bool isSearch = false;
    public GameObject Target;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Stay()
    {
        animator.SetBool("Aiming", false);
        animator.SetFloat("Speed", 0f);
    }

    public void Walk()
    {
        animator.SetBool("Aiming", false);
        animator.SetFloat("Speed", 0.5f);
    }

    public void Run()
    {
        animator.SetBool("Aiming", false);
        animator.SetFloat("Speed", 1f);
    }

    public void Attack()
    {
        Aiming();
        animator.SetTrigger("Attack");
    }

    public void Damage()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Death")) return;
        int id = Random.Range(0, countOfDamageAnimations);
        if (countOfDamageAnimations > 1)
            while (id == lastDamageAnimation)
                id = Random.Range(0, countOfDamageAnimations);
        lastDamageAnimation = id;
        animator.SetInteger("DamageID", id);
        animator.SetTrigger("Damage");
    }

    public void Jump()
    {
        animator.SetBool("Squat", false);
        animator.SetFloat("Speed", 0f);
        animator.SetBool("Aiming", false);
        animator.SetTrigger("Jump");
    }

    public void Aiming()
    {
        animator.SetBool("Squat", false);
        animator.SetFloat("Speed", 0f);
        animator.SetBool("Aiming", true);
    }

    public void Sitting()
    {
        animator.SetBool("Squat", !animator.GetBool("Squat"));
        animator.SetBool("Aiming", false);
    }

    void Start()
    {
        Sitting();
        originPos = transform.localPosition;
        vibration = objectToVibrate.GetComponent<Vibration>();
    }

    void Update()
    {
        //탐색하다 걸리면 공격, 아니면 평소대로 패트롤
        if (isSearch == true)
        {
            //기존과 탐색 조건을 추가함
            AttackAct();
        }
        else
        {
            Walk();
            WayPointMove(); //패트롤 기능
        }
    }

    void WayPointMove()
    {
        if (isWayPoint == false)
        {
            //회전
            transform.rotation =
                Quaternion.Slerp(transform.rotation,
                    Quaternion.LookRotation(WayPoint1.transform.position - transform.position), 1);
            //이동
            transform.Translate(Vector3.forward * Time.smoothDeltaTime * MoveSpeed);
            //반전
            if (Vector3.Distance(transform.position, WayPoint1.transform.position) <= 0.5f)
                isWayPoint = true;
        }
        else
        {
            //회전
            transform.rotation =
                Quaternion.Slerp(transform.rotation,
                    Quaternion.LookRotation(WayPoint0.transform.position - transform.position), 1);
            //이동
            transform.Translate(Vector3.forward * Time.smoothDeltaTime * MoveSpeed);
            //반전
            if (Vector3.Distance(transform.position, WayPoint0.transform.position) <= 0.5f)
                isWayPoint = false;
        }

        Search(); //탐색기능 <-New Challenger!!
    }

    void Search()
    {
        float distance = Vector3.Distance(Target.transform.position, transform.position);
        //거리가 가까워지면 탐색에 걸림
        if (distance <= 5)
            isSearch = true;
    }

    void AttackAct()
    {
        if (PauseMenu.getPaused == false)
        {
            //vibration.StartShaking(new Vector3(xVibe, yVibe, zVibe), new Quaternion(xRot, yRot, zRot, 1), speed, diminish, numberOfShakes);
            Attack();
            PlayerHealth.currentHealth -= 0.5f;
            //돌아보는 방향을 플레이어 쪽으로
            transform.rotation =
                Quaternion.Slerp(transform.rotation,
                    Quaternion.LookRotation(Target.transform.position - transform.position), Time.smoothDeltaTime * 5.0f);
            float distance = Vector3.Distance(Target.transform.position, transform.position);
            //거리가 멀어지면 탐색 실패
            if (distance > 5)
                isSearch = false;
        }
        else ;
    }

    void Shoot()
    {
        GameObject bullet = ObjectPool.Instance.PopFromPool(bulletName);
        CreateBullet();        
    }

    void CreateBullet()
    {
        Instantiate(Bullet, firePos.position, firePos.rotation);
    }
}
