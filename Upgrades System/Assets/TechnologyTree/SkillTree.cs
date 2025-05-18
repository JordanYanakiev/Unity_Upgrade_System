using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTree : MonoBehaviour
{
    public static SkillTree skillTree;

    public int[] skillLevels;
    public int[] skillCaps;
    public int[] skillPercents;
    public string[] skillNames;
    public string[] skillDescriptions;
    public List<Skill> skillsList;
    public GameObject skillHolder;
    public List<GameObject> connectorsList;
    public GameObject connectorHolder;
    public int skillPoints;
    public TechTreeSO techTreeSO;


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        skillTree = this;
    }

    private void Start()
    {
        //if (!techTreeSO.isInitializedOnce)
        {
            skillPoints = 20;
            skillLevels = new int[6];
            skillCaps = new[] { 1, 5, 5, 2, 10, 10 };
            skillNames = new[] { "Ability01", "Ability02", "Ability03", "Ability04", "Ability05", "Ability06" };
            skillDescriptions = new[]
            {
            "Does something cool 01",
            "Does something cool 02",
            "Does something cool 03",
            "Does something cool 04",
            "Does something cool 05",
            "Does something cool 06"
            };
            skillPercents = new int[skillCaps.Length];
            techTreeSO.isInitializedOnce = true;
        }

        foreach (var skill in skillHolder.GetComponentsInChildren<Skill>())
        {
            skillsList.Add(skill);
        }
        
        foreach (var connector in connectorHolder.GetComponentsInChildren<RectTransform>())
        {
            connectorsList.Add(connector.gameObject);
        }


        UpdateAllSkillUI();

        for (int i = 0; i < skillsList.Count; i++) skillsList[i].id = i;


    }

    public void UpdateAllSkillUI()
    {
        int counter = 0;
        foreach (var skill in skillsList) 
        { 
            skill.UpdateUI();
            skillPercents[skill.id] = skill.bonusPercent;
            UpdateTechTreeSO(skill, counter);
            //skill.bonusPercent = skillPercents[counter];

            counter++;
        }
    }

    private void UpdateTechTreeSO(Skill skill, int counter)
    {

        techTreeSO.skillsList[counter].id = skill.id;
        techTreeSO.skillsList[counter].technologyName = skillNames[counter];
        techTreeSO.skillsList[counter].technologyLevel = skillLevels[counter];
        techTreeSO.skillsList[counter].bonusPercent = skill.bonusPercent;
        if (techTreeSO.skillsList[counter].connectedSkills.Length <= 0)
        {
            techTreeSO.skillsList[counter].connectedSkills = new int[skill.connectedSkills.Length];

            for (int i = 0; i < skill.connectedSkills.Length; i++)
            {
                techTreeSO.skillsList[counter].connectedSkills[i] = skill.connectedSkills[i];
            }
        }

    }


}
