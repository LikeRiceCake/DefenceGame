//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class Enemy : MonoBehaviour
//{
//    public EnemyManager EM;
//    Soldier soldier;
//    public Animator anim;
//    public Animator SoldierAnim;
//    SpriteRenderer sr;

//    public int EnemyHp;
//    [SerializeField]
//    int AttackDamage;
//    float moveSpeed;

//    bool isMeet;
//    bool isBroken;

//    int choice;

//    public bool isdie = false;

//    private void Awake()
//    {
//        anim = gameObject.GetComponent<Animator>();
//        sr = gameObject.GetComponent<SpriteRenderer>();
//    }

//    private void Start()
//    {
//        EnemyHp = 6 + (int)((EM.resources.round / 5) * 1.2);
//        AttackDamage = 1 + (EM.resources.round / 5);
//        moveSpeed = 3f;
//        isBroken = false;
//        isMeet = false;
//        choice = 0;
//        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180f, transform.rotation.z);
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if(transform.position.x <= 10)
//        {
//            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1);
//        }
//        else
//        {
//            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0);
//        }
//        enemyMove();
//    }

//    void enemyMove()
//    {
//        if (transform.position.x >= -5f && !isMeet && !isdie)
//        {
//            anim.SetBool("isIdle", false);
//            anim.SetBool("isAttack", false);
//            anim.SetBool("isWalk", true);
//            transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
//        }
//    }

//    private void OnTriggerStay2D(Collider2D collision)
//    {
//        if (collision.transform.CompareTag("Castle"))
//        {
//            anim.SetBool("isWalk", false);
//            isMeet = true;
//            choice = 2;
//            anim.SetBool("isAttack", true);
//        }
//    }

//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.transform.CompareTag("Soldier"))
//        {
//            anim.SetBool("isWalk", false);
//            choice = 1;
//            isMeet = true;
//            soldier = collision.GetComponent<Soldier>();
//            SoldierAnim = collision.GetComponent<Animator>();
//            anim.SetBool("isAttack", true);
//        }
//        if (collision.transform.CompareTag("Castle"))
//        {
//            anim.SetBool("isWalk", false);
//            isMeet = true;
//            choice = 2;
//            anim.SetBool("isAttack", true);
//        }
//        if (collision.transform.CompareTag("Meteor"))
//        {
//            Destroy(collision.gameObject);
//            isdie = true;
//            anim.SetBool("isAttack", false);
//            anim.SetBool("isWalk", false);
//            anim.SetBool("isDie", true);
//        }
//    }

//    private void OnTriggerExit2D(Collider2D collision)
//    {
//        if (collision.transform.CompareTag("Soldier"))
//        {
//            isMeet = false;
//        }
//    }
//    public void InAttack()
//    {
//        if (choice == 2)
//        {
//            EM.cs.CurrentCastleHP -= AttackDamage;
//            if (EM.cs.CurrentCastleHP <= 0f)
//            {
//                EM.cs.CurrentCastleHP = 0;
//                EM.gameObject.SetActive(false);
//                EM.fd.gameObject.SetActive(true);
//                EM.bd.isBattle = false;
//                isBroken = true;
//                anim.SetBool("isWalk", false);
//                anim.SetBool("isAttack", false);
//                anim.SetBool("isIdle", true);
//                if(EM.bd.isBackRound)
//                {
//                    EM.bd.isBackRound = false;
//                    EM.resources.round++;
//                    EM.resources.setRound();
//                }
//            }
//        }
//        if (choice == 1)
//        {
//            soldier.Hp -= AttackDamage;
//            if (soldier.Hp <= 0)
//            {
//                SoldierAnim.SetBool("isIdle", false);
//                SoldierAnim.SetBool("isWalk", false);
//                SoldierAnim.SetBool("isAttack", false);
//                SoldierAnim.SetBool("isDie", true);
//            }
//        }
//    }
//    public void InDie_Enemy()
//    {
//        EM.resources.resources[0] += Random.Range(10, 31);
//        EM.resources.setResources();
//        --EM.enemyMax;
//        EM.enemycntText.text = EM.enemyMax.ToString();
//         if (EM.enemyMax <= 0)
//        {
//            EM.gameObject.SetActive(false);
//            EM.sd.gameObject.SetActive(true);
//            EM.resources.resources[0] += ((100 * EM.resources.round) + 50);
//            EM.resources.setResources();
//            EM.resources.round++;
//            EM.resources.setRound();
//            if(EM.bd.isBackRound)
//            {
//                EM.bd.isBackRound = false;
//            }
//        }
//        gameObject.SetActive(false);
//    }
//}
