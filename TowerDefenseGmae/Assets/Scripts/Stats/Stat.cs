using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat
{
    public float baseValue;
    public List<StatModifier> statModifiers = new List<StatModifier>();
    public float currentFinalValue;
    private StatModifier currentModifier;

    /// <summary>
    /// Recalculates the value of this stat
    /// Can be overriden to allow negative calculations
    /// </summary>
    public virtual void Recalculate()
    {
        Value v = new Value(baseValue);
        foreach(StatModifier modifier in statModifiers)
        {
            modifier.ModifyValue(v);
        }
        currentFinalValue = v.Calculate();
    }

    /// <summary>
    /// Creates a stat modifier based on the value of this stat
    /// Virtual method creating a StatModifier
    /// Override and create logic
    /// </summary>
    /// <returns></returns>
    public virtual StatModifier GetModifier()
    {
        // If it does not exist yet, perform creation
        if (currentModifier == null)
            currentModifier = new StatModifier(0, 0, 0, 0);

        // Adjust the mods
        currentModifier.AdjustMods(0, 0, 0, 0);

        // Return the current modifier
        return currentModifier;
    }

    /// <summary>
    /// Get the flat value of this stat
    /// </summary>
    public float GetStatValue()
    {
        return currentFinalValue;
    }

    /// <summary>
    /// Adds a stat modifier to the list of modifiers,
    /// if it is not already there
    /// </summary>
    /// <param name="m"></param>
    public void AddModifier(StatModifier m)
    {
        if (!statModifiers.Contains(m))
        {
            statModifiers.Add(m);
        }
    }

    /// <summary>
    /// Removes a modifier from the list of stat modifiers,
    /// if it is already there
    /// </summary>
    /// <param name="m"></param>
    public void RemoveModifier(StatModifier m)
    {
        if (statModifiers.Contains(m))
        {
            statModifiers.Remove(m);
        }
    }

    /// <summary>
    /// Returns a string for how this stat should be represented as an entry in a Stat List
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return "" + currentFinalValue;
    }
}
