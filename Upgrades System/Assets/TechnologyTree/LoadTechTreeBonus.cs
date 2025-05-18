using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LoadTechTreeBonus : MonoBehaviour
{
    public static LoadTechTreeBonus loadTecTreeBonus;
    public int[] activeBonuses;
    public TechTreeSO techTreeSO;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        loadTecTreeBonus = this;

        activeBonuses = new int[SkillTree.skillTree.skillsList.Count];

        foreach(var skill in SkillTree.skillTree.skillsList)
        {
            activeBonuses[skill.id] = skill.bonusPercent;
        }

        Debug.Log($"Ability03 bonus = {GetAbility03Bonus()}");
    }

    private void Update()
    {
        foreach (var skill in SkillTree.skillTree.skillsList)
        {
            activeBonuses[skill.id] = skill.bonusPercent;
        }
    }


    public int GetAbility03Bonus()
    {
        var technology = techTreeSO.skillsList.LastOrDefault(t => t.technologyName == "Ability03");
        int bonus = technology.bonusPercent;
        return bonus;
    }

}
