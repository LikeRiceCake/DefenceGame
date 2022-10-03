//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Ballistar : MonoBehaviour
//{
//    public Buttons_Deffnece bd;
//    public List<GameObject> enemyPos = new List<GameObject>();
//    public Transform firepos;
//    public Ballistar BS;

//    public int Damage;
//    float FindEnemyRange;

//    Vector3 dir;
//    float dis;
//    public Transform Ballistar_Target;
//    public bool isfireEnd;

//    private void Start()
//    {
//        BS = this;
//        Damage = 5;
//        FindEnemyRange = 25f;
//        isfireEnd = true;
//    }

//    void Update()
//    {
//        findEnemy();
//    }

//    void findEnemy()
//    {
//        if (bd.isBattle)
//        {
//            Ballistar_Target = null;

//            float range = FindEnemyRange;

//            for (int i = 0; i < enemyPos.Count; i++)
//            {
//                if (!enemyPos[i].activeSelf)
//                    continue;
//                dis = Vector3.Distance(enemyPos[i].transform.position, transform.position);

//                if (dis < range)
//                {
//                    range = dis;
//                    Ballistar_Target = enemyPos[i].transform;
//                }
//            }
//            if (Ballistar_Target)
//            {
//                dir = Ballistar_Target.transform.position - transform.position;
//                dir = dir.normalized;
//                if (dis < FindEnemyRange)
//                {
//                    if(isfireEnd &&  bd.isBattle)
//                    {

//                        isfireEnd = false;
//                        GameObject obj = Instantiate(bd.Ballistar_Bullet, firepos.position, Quaternion.identity);
//                        obj.GetComponent<Ballistar_Bullet>().EnemyPos = Ballistar_Target;
//                        obj.GetComponent<Ballistar_Bullet>().damage = Damage;
//                        obj.GetComponent<Ballistar_Bullet>().bs = BS;
//                        StartCoroutine(DestroyGameObject());
//                    }
//                }
//            }
//        }
//    }
//    IEnumerator DestroyGameObject()
//    {
//        {
//            yield return new WaitForSeconds(3f);
//            isfireEnd = true;
//        }
//    }
//}
