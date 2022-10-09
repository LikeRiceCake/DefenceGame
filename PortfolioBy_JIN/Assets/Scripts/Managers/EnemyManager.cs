using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    #region //enumeration//
    IEnumerator _coroutineManager;
    #endregion

    #region //variable//
    //-------------------------------------------- public

    //-------------------------------------------- private
    int maxEnemyCnt;
    int currentEnemyCnt;
    #endregion

    #region //constant//
    //-------------------------------------------- public
    public const int DefaultMaxEnemyCnt = 5;
    //-------------------------------------------- private

    #endregion

    #region //class//
    //-------------------------------------------- public

    //-------------------------------------------- private
    List<GameObject> enemyList = new List<GameObject>();

    ResourceManager resourceManager;

    DataManager dataManager;

    GameObject enemyObject;

    Transform enemyPos;

    CharacterFactory<EnemyFactory._EEnemyClass_> enemyFactory;
    #endregion

    #region //property//
    public IEnumerator coroutineManager { get { return _coroutineManager; } }
    #endregion

    #region //unityLifeCycle//
    private void OnEnable()
    {
        
    }

    private void Start()
    {
        DataInit();
        CreateEnemy();
    }
    #endregion

    #region //function//
    //-------------------------------------------- public
    public void DataInit()
    {
        resourceManager = ResourceManager.instance;
        dataManager = DataManager.instance;

        enemyPos = GameObject.Find("Canvas").transform.Find("BattleFrame").transform.Find("EnemyPos").transform;

        enemyObject = resourceManager.LoadCharacterResource("Prefabs/Enemy");

        enemyFactory = gameObject.AddComponent<EnemyFactory>();

        MaximumEnemy();

        _coroutineManager = ActivateEnemy();
    }

    public void CreateEnemy() // 적 생성
    {
        GameObject hierarchyEnemyList = new GameObject();
        hierarchyEnemyList.name = "EnemyList";
        for (int i = 0; i < maxEnemyCnt; i++)
        {
            GameObject enemy = enemyFactory.Create(EnemyFactory._EEnemyClass_.eecEnemy);
            enemy.transform.SetParent(hierarchyEnemyList.transform);
            enemy.name = "Enemy_" + i.ToString("00");
            enemy.GetComponent<Enemy>().enemyManager = this;
            enemy.SetActive(false);
            enemy.transform.position = enemyPos.position;
            enemyList.Add(enemy);
        }
    }

    public void MaximumEnemy() // 적의 최대 갯수 설정
    {
        maxEnemyCnt = DefaultMaxEnemyCnt + (dataManager.myUserInfo.m_nWave / 2);
        CurrentEnemySetting();
    }

    public void CurrentEnemySetting() // 적의 현재 갯수 설정
    {
        currentEnemyCnt = maxEnemyCnt;
    }

    public void CurrentEnemyDecrease() // 적의 현재 갯수 감소
    {
        currentEnemyCnt--;
        if(currentEnemyCnt <= 0)
        {
            // 디펜스 승리
        }
    }

    public IEnumerator ActivateEnemy() // 적 소환
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            yield return new WaitForSeconds(1f);
            enemyList[i].SetActive(true);
        }
        StopCoroutine(_coroutineManager);
    }
    //-------------------------------------------- private

    #endregion
}
