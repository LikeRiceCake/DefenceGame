using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : Singleton<SkillManager>
{
    #region //enumeration//
    public enum _ESkillClass_
    {
        escMeteor,
        escMax
    }

    Coroutine _coroutineManager;
    #endregion

    #region //class//
    SkillFactory[] skillFactory;

    List<GameObject>[] skillList = new List<GameObject>[(int)_ESkillClass_.escMax];

    SkillCreateInfo[] skillCreateInfo;
    #endregion

    #region //property//
    public Coroutine coroutineManager { get { return _coroutineManager; } }
    #endregion

    #region //unityLifeCycle//
    void OnEnable()
    {
        DataInit();
    }
    #endregion

    #region //function//
    public void DataInit()
    {
        skillFactory = new SkillFactory[(int)_ESkillClass_.escMax];

        skillCreateInfo = new SkillCreateInfo[(int)_ESkillClass_.escMax];

        skillFactory[(int)_ESkillClass_.escMeteor] = gameObject.AddComponent<MeteorFactory>();

        skillCreateInfo = GetComponent<SkillCreateInfoPocket>().skillCreateInfo;

        for (int i = 0; i < (int)_ESkillClass_.escMax; i++)
            skillList[i] = new List<GameObject>();
    }

    public void CreateSkill() // 스킬 오브젝트 제작
    {
        for (int i = 0; i < (int)_ESkillClass_.escMax; i++)
        {
            skillList[i].RemoveRange(0, skillList[i].Count);
        }

        for (int i = 0; i < (int)_ESkillClass_.escMax; i++)
        {
            GameObject hierarchySkillList = new GameObject();
            hierarchySkillList.name = "SkillList_" + (i + 1);

            for (int j = 0; j < skillCreateInfo[i].NumberOfObject; j++)
            {
                GameObject skill = skillFactory[i].Create();
                skill.transform.SetParent(hierarchySkillList.transform);
                skill.name = "__" + (i + 1) + "_Skill" + "_" + j.ToString("00");
                skill.SetActive(false);
                skillList[i].Add(skill);
            }
        }
    }

    public void SkillActivateCoroutineStart(_ESkillClass_ select) // 스킬 사용 coroutine 실행
    {
        _coroutineManager = StartCoroutine(SkillActivate((int)select));
    }

    public void SkillActivateCoroutineStop() // 스킬 사용 coroutine 중지
    {
        if (_coroutineManager != null)
            StopCoroutine(_coroutineManager);
    }

    public IEnumerator SkillActivate(int select) // 스킬 사용
    {
        for(int i = 0; i < skillList[select].Count; i++)
        {
            skillList[select][i].gameObject.SetActive(true);
            yield return new WaitForSeconds(skillCreateInfo[select].RateOfFire);
        }
    }

    public void SceneLoadedSkills()
    {
       if(GameManager.instance.currentSceneState == GameManager._ESceneState_.esDefence)
            CreateSkill();
    }
    #endregion
}
