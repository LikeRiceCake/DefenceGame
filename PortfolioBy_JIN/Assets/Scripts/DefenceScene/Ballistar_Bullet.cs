//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Ballistar_Bullet : MonoBehaviour
//{
//    public Transform EnemyPos;
//    public int damage;
//    public Ballistar bs;
//    Enemy enemy;
//    Animator enemyanim;
//    float angle;
//    // Update is called once per frame
//    void Update()
//    {
//        if (EnemyPos)
//        {
//            Vector3 dir = EnemyPos.position - transform.position;

//            angle = Mathf.Atan2(EnemyPos.position.y - transform.position.y, EnemyPos.position.x - transform.position.x) * Mathf.Rad2Deg;
//            this.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
//            transform.Translate(Vector3.up * Time.deltaTime * 5);
//        }
//        else
//        {
//            Destroy(gameObject);
//        }
//    }

//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if(collision.transform.CompareTag("Enemy"))
//        {
//            enemy = collision.GetComponent<Enemy>();
//            enemyanim = collision.GetComponent<Animator>();
//            enemy.EnemyHp -= damage;
//            if (enemy.EnemyHp <= 0)
//            {
//                enemyanim.SetBool("isIdle", false);
//                enemyanim.SetBool("isWalk", false);
//                enemyanim.SetBool("isAttack", false);
//                enemyanim.SetBool("isDie", true);
//            }
//            Destroy(gameObject);
//        }
//    }
//}
