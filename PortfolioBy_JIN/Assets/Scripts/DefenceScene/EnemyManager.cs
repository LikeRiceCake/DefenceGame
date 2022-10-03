//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class EnemyManager : MonoBehaviour
//{
//    public GameObject enemy;
//    public Castle cs;
//    public FailedDeffenceVisiblle fd;
//    public Soldier[] soldier;
//    public portPlayerPrefs resources;
//    public GameObject sd;
//    public Buttons_Deffnece bd;
//    EnemyManager em;

//    public Text enemycntText;

//    public List<GameObject> EnemyPool = new List<GameObject>();
//    public int enemyMax;
//    int cnt;

//    private void Awake()
//    {
//        cnt = 0;
//        gameObject.SetActive(false);
//        em = this;
//        enemyMax = 5;
//    }

//    private void Start()
//    {
//        CreateEnemy();
//    }

//    void OnEnable()
//    {
//        enemyMax = 5 + resources.round;
//        enemycntText.text = enemyMax.ToString();
//        StartCoroutine(SetEnemy(enemyMax, cnt));
//    }

//    IEnumerator SetEnemy(int enemyMax, int cnt)
//    {
//        yield return new WaitForSeconds(1f);
//        if (cnt >= enemyMax)
//            yield break;
//        Vector2 Pos = new Vector2(15f, Random.Range(0f, -5f));
//        EnemyPool[cnt].SetActive(true);
//        EnemyPool[cnt].transform.position = Pos;
//        cnt++;

//        StartCoroutine(SetEnemy(enemyMax, cnt));
//    }

//    void CreateEnemy()
//    {
//        GameObject enemyParent = new GameObject();
//        enemyParent.name = "EnemyParent";
//        for (int i = 0; i < enemyMax; i++)
//        {
//            GameObject obj = Instantiate(enemy, enemyParent.transform);
//            obj.gameObject.GetComponent<Enemy>().EM = em;
//            obj.name = "Enemy_" + i.ToString("00");
//            obj.SetActive(false);
//            obj.transform.position = new Vector3(20, 0, 0);
//            EnemyPool.Add(obj);
//        }
//    }
//}
