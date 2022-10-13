using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    #region //enumeration//
    public enum _EEnemyClass_
    {
        eecEnemy,
        eecMax
    }

    Coroutine _coroutineManager;
    #endregion

    #region //variable//
    int _maxEnemyCnt;
    int _currentEnemyCnt;
    #endregion

    #region //constant//
    public const int DefaultMaxEnemyCnt = 5;
    #endregion

    #region //class//
    List<GameObject> enemyList = new List<GameObject>();

    DataManager dataManager;

    UIManager uiManager;

    CharacterFactory<_EEnemyClass_> enemyFactory;
    #endregion

    #region //property//
    public int currentEnemyCnt { get { return _currentEnemyCnt; } set { _currentEnemyCnt = value; } }

    public Coroutine coroutineManager { get { return _coroutineManager; } set { _coroutineManager = value; } }
    #endregion

    #region //unityLifeCycle//
    private void OnEnable()
    {
        DataInit();
    }
    #endregion

    #region //function//
    public void DataInit()
    {
        dataManager = DataManager.instance;
        uiManager = UIManager.instance;

        enemyFactory = gameObject.AddComponent<EnemyFactory>();
    }

    public void CreateEnemy() // �� ����
    {
        enemyList.RemoveRange(0, enemyList.Count);

        GameObject hierarchyEnemyList = new GameObject();
        hierarchyEnemyList.name = "EnemyList";

        for (int i = 0; i < _maxEnemyCnt; i++)
        {
            GameObject enemy = enemyFactory.Create(_EEnemyClass_.eecEnemy);
            enemy.transform.SetParent(hierarchyEnemyList.transform);
            enemy.name = "Enemy_" + i.ToString("00");
            enemy.GetComponent<Enemy>().enemyManager = this;
            enemy.SetActive(false);
            enemy.transform.position = ObjectManager.instance.enemySummonPos.transform.position;
            enemyList.Add(enemy);
        }
    }

    public void MaximumEnemy() // ���� �ִ� ���� ����
    {
        _maxEnemyCnt = DefaultMaxEnemyCnt + (dataManager.myUserInfo.m_nWave / 2);
        CurrentEnemySetting();
    }

    public void CurrentEnemySetting() // ���� ���� ���� ����
    {
        _currentEnemyCnt = _maxEnemyCnt;
    }

    public void CurrentEnemyDecrease() // ���� ���� ���� ����
    {
        _currentEnemyCnt--;
        uiManager.SetTextEnemyCount();
        if (currentEnemyCnt <= 0)
        {
            BattleManager.instance.Victory();
        }
    }

    public void EnemyActivateCoroutineStop() // EnemyActivate �ڷ�ƾ ����
    {
        if (_coroutineManager != null)
            StopCoroutine(_coroutineManager);
    }

    public void EnemyActivateCoroutineStart() // EnemyActivate �ڷ�ƾ ����
    {
        _coroutineManager = StartCoroutine(ActivateEnemy());
    }

    public IEnumerator ActivateEnemy() // �� ��ȯ
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            yield return new WaitForSeconds(1f);
            enemyList[i].SetActive(true);
        }
    }

    public void SceneLoadedEnemys()
    {
        if (GameManager.instance.currentSceneState == GameManager._ESceneState_.esDefence)
        {
            MaximumEnemy();
            CreateEnemy();
        }
    }
    #endregion
}
