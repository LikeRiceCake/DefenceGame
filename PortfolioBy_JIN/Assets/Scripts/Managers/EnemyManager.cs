using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    #region //enumeration//
    Coroutine _coroutineManager;
    #endregion

    #region //variable//
    //-------------------------------------------- public

    //-------------------------------------------- private
    int _maxEnemyCnt;
    int _currentEnemyCnt;
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

    UIManager uiManager;

    GameObject enemyObject;

    Transform enemyPos;

    CharacterFactory<EnemyFactory._EEnemyClass_> enemyFactory;
    #endregion

    #region //property//
    public Coroutine coroutineManager { get { return _coroutineManager; } set { _coroutineManager = value; } }
    public int currentEnemyCnt { get { return _currentEnemyCnt; } set { _currentEnemyCnt = value; } }
    #endregion

    #region //unityLifeCycle//
    private void OnEnable()
    {
        DataInit();
    }

    private void Start()
    {
       
    }
    #endregion

    #region //function//
    //-------------------------------------------- public
    public void DataInit()
    {
        resourceManager = ResourceManager.instance;
        dataManager = DataManager.instance;
        uiManager = UIManager.instance;

        enemyObject = resourceManager.LoadCharacterResource("Prefabs/Enemy");

        enemyFactory = gameObject.AddComponent<EnemyFactory>();

        MaximumEnemy();
    }

    public void CreateEnemy() // 적 생성
    {
        enemyList.RemoveRange(0, enemyList.Count);
        GameObject hierarchyEnemyList = new GameObject();
        hierarchyEnemyList.name = "EnemyList";
        for (int i = 0; i < _maxEnemyCnt; i++)
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
        _maxEnemyCnt = DefaultMaxEnemyCnt + (dataManager.myUserInfo.m_nWave / 2);
        CurrentEnemySetting();
    }

    public void CurrentEnemySetting() // 적의 현재 갯수 설정
    {
        _currentEnemyCnt = _maxEnemyCnt;
    }

    public void CurrentEnemyDecrease() // 적의 현재 갯수 감소
    {
        _currentEnemyCnt--;
        uiManager.SetTextEnemyCount();
        if (currentEnemyCnt <= 0)
        {
            dataManager.myUserInfo.m_nWave++;
            uiManager.SetFrameEndDefence(BattleManager._EDefenceResult_.edrVictory);
        }
    }

    public void ResetEnemyManager() // RedoButton같이 디펜스를 재시작하거나 할 때 리셋
    {
        if(_coroutineManager != null)
            StopCoroutine(_coroutineManager);
    }

    public void CoroutineStart()
    {
        _coroutineManager = StartCoroutine(ActivateEnemy());
    }

    public IEnumerator ActivateEnemy() // 적 소환
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            yield return new WaitForSeconds(1f);
            enemyList[i].SetActive(true);
        }
    }

    public void SceneLoadedEnemys()
    {
        ResetEnemyManager();
        enemyPos = GameObject.Find("Canvas").transform.Find("BattleFrame").transform.Find("EnemySummonPos").transform;
        MaximumEnemy();
        CreateEnemy();
    }
    //-------------------------------------------- private

    #endregion
}
