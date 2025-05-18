using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static SkillTree;

[Serializable]
public class Skill : MonoBehaviour
{
    public int id;
    public TMP_Text titleText;
    public TMP_Text descriptionText;
    public int[] connectedSkills;
    public int bonusPercent;
    public string technologyBnusType;

    public void UpdateUI()
    {
        titleText.text = $"{skillTree.skillLevels[id]}/{skillTree.skillNames[id]}";
        descriptionText.text = $"{skillTree.skillDescriptions[id]}\nCost:{skillTree.skillPoints}/1 SP";

        GetComponent<Image>().color = skillTree.skillLevels[id] >= skillTree.skillCaps[id] ? Color.yellow : skillTree.skillPoints >= 1 ? Color.green : Color.white;

        foreach (var connectedSkill in connectedSkills)
        {
            skillTree.skillsList[connectedSkill].gameObject.SetActive(skillTree.skillLevels[id] > 0);
            skillTree.connectorsList[connectedSkill].SetActive(skillTree.skillLevels[id] > 0);
        }
    }

    public void Buy()
    {
        if (skillTree.skillPoints < 1 || skillTree.skillLevels[id] >= skillTree.skillCaps[id]) return;

        skillTree.skillPoints -= 1;
        skillTree.skillLevels[id]++;
        bonusPercent++;
        skillTree.UpdateAllSkillUI();
    }
}
