//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Soldier : MonoBehaviour
//{
//    [HideInInspector]
//    public Buttons_Deffnece BD;
//    public List<GameObject> enemyPos = new List<GameObject>();
//    public EnemyManager em;
//    public portPlayerPrefs resources;
//    public Animator anim;
//    public Animator EnemyAnim;

//    Enemy enemy;

//    public int Hp;
//    public int Damage;
//    public float Speed;
//    float FindEnemyRange;
//    bool isMeet;

//    Vector2 dir;
//    float dis;
//    public Transform soldierTarget;

//    private void Awake()
//    {
//        anim = gameObject.GetComponent<Animator>();
//    }

//    private void Start()
//    {
//        FindEnemyRange = 25f;
//        isMeet = false;
//    }

//    void Update()
//    {
//        findEnemy();
//    }

//    void findEnemy()
//    {
//        if (BD.isBattle)
//        {
//            soldierTarget = null;

//            float range = FindEnemyRange;

//            for (int i = 0; i < enemyPos.Count; i++)
//            {
//                if (!enemyPos[i].activeSelf)
//                    continue;
//                dis = Vector2.Distance(enemyPos[i].transform.position, transform.position);

//                if (dis < range)
//                {
//                    range = dis;
//                    soldierTarget = enemyPos[i].transform;
//                }
//            }
//            if (soldierTarget)
//            {
//                dir = soldierTarget.transform.position - transform.position;
//                dir = dir.normalized;
//                if (!isMeet && dis < FindEnemyRange)
//                {
//                    anim.SetBool("isIdle", false);
//                    anim.SetBool("isAttack", false);
//                    anim.SetBool("isWalk", true);
//                    transform.Translate(dir * Speed * Time.deltaTime);
//                    float LimitX = Mathf.Clamp(transform.position.x, -5f, 8f);
//                    Vector3 LimitPos = new Vector3(LimitX, transform.position.y, transform.position.z);

//                    transform.position = LimitPos;
//                }
//            }
//        }
//    }

//    private void OnTriggerStay2D(Collider2D collision)
//    {
//        if (collision.transform.CompareTag("Enemy"))
//        {
//            anim.SetBool("isWalk", false);
//            isMeet = true;
//            enemy = collision.GetComponent<Enemy>();
//            EnemyAnim = collision.GetComponent<Animator>();
//            anim.SetBool("isAttack", true);
//        }
//    }

//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.transform.CompareTag("Enemy"))
//        {
//            anim.SetBool("isWalk", false);
//            isMeet = true;
//            enemy = collision.GetComponent<Enemy>();
//            EnemyAnim = collision.GetComponent<Animator>();
//            anim.SetBool("isAttack", true);
//        }
//    }
//    private void OnTriggerExit2D(Collider2D collision)
//    {
//        if (collision.transform.CompareTag("Enemy"))
//        {
//            isMeet = false;
//        }
//    }

//    public void InAttack_Enemy()
//    {
//        enemy.EnemyHp -= Damage;
//        if (enemy.EnemyHp <= 0)
//        {
//            enemy.isdie = true;
//            EnemyAnim.SetBool("isIdle", false);
//            EnemyAnim.SetBool("isWalk", false);
//            EnemyAnim.SetBool("isAttack", false);
//            EnemyAnim.SetBool("isDie", true);
//        }
//        if(em.enemyMax <= 0)
//        {
//            anim.SetBool("isWalk", false);
//            anim.SetBool("isAttack", false);
//            anim.SetBool("isIdle", true);
//        }
//    }

//    public void InDie_Soldier()
//    {
//        gameObject.SetActive(false);
//    }
//}
