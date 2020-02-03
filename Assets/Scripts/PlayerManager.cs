using Exsersewo.Nydaliv.Utilities;
using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [InspectorButton(nameof(TestGiveExperience), 250f)]
    public bool button;

    [SerializeField]
    private string playerName;
    
    [SerializeField]
    private float health = 100;
    private float maxHealth = 100;

    [SerializeField]
    private ulong experience = 0;
    [SerializeField]
    private ulong totalExperience = 0;
    [SerializeField]
    private ulong level = 1;

    /// <summary>
    /// <para>OnLevelUp Subscribable Function</para>
    /// <para>ulong = level currently at</para>
    /// </summary>
    public Action<ulong> OnLevelUp;

    public string GetName()
        => playerName;

    public float GetHealth()
        => health;
    public float GetMaxHealth()
        => maxHealth;

    public ulong GetExperience()
        => experience;
    public ulong GetExperienceToNextLevel()
        => NumberUtilities.GetXPLevelRequirement(level + 1, Props.PHI);
    public ulong GetTotalExperience()
        => totalExperience;

    public ulong GetLevel()
        => level;

    public string SetName(string value)
        => playerName = value;

    public float SetHealth(float amount)
    {
        health = amount;

        if (health > maxHealth)
            health = maxHealth;

        return health;
    }

    public float AddHealth(float amount)
    {
        health += amount;
        
        if (health > maxHealth)
            health = maxHealth;

        return health;
    }

    public void AddExperience(ulong amount)
    {
        totalExperience += amount;
        experience += amount;

        HandleExperience();
    }

    void HandleExperience()
    {
        ulong backUpExperience = experience;
        ulong lvl = level;

        ulong requiredXp = NumberUtilities.GetXPLevelRequirement(lvl + 1, Props.PHI);
        while (backUpExperience >= requiredXp)
        {
            backUpExperience -= requiredXp;
            requiredXp = NumberUtilities.GetXPLevelRequirement(lvl + 1, Props.PHI);

            lvl++;

            maxHealth = (float)Math.Ceiling(maxHealth *= Props.PHI);
            health = maxHealth;

            if (OnLevelUp != null)
            {
                OnLevelUp.Invoke(level);
            }
        }

        GameManager.instance.playerCanvas.SetExperienceBar(backUpExperience, requiredXp);

        experience = backUpExperience;
        level = lvl;
    }

    void TestGiveExperience()
    {
        AddExperience((ulong)UnityEngine.Random.Range(1, 500));
    }


    
    void Update()
    {
        GameManager.instance.playerCanvas.SetNameText(GetName());
        GameManager.instance.playerCanvas.SetHealthValue((ulong)GetHealth(), (ulong)GetMaxHealth());
        GameManager.instance.playerCanvas.SetLevelValue($"{GetLevel()}");
    }
}
