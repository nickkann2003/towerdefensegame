using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Value
{
    // Numerical value
    public float value;
    // Multiplicative percentages, multiplied together
    public float multiplicativePercentages = 1.0f;
    // Additive percentages, percentages that stack additively
    public float additivePercentages = 1.0f;
    // True value, values that are not affected by percentages
    public float trueValue;
    // Can this value become negative if it is reduced enough
    public bool canNegative;
    // Can this value become negative through the use of True Values
    public bool canTrueNegative;

    public Value(float initialValue)
    {
        this.value = initialValue;
    }

    public Value(float initialValue, bool canNegative, bool canTrueNegative)
    {
        this.value = initialValue;
        this.canNegative = canNegative;
        this.canTrueNegative = canTrueNegative;
    }

    public Value(float initialValue, float multiplicativePercentages, float additivePercentages, float trueValue, bool canNegative, bool canTrueNegative)
    {
        this.value=initialValue;
        this.multiplicativePercentages=multiplicativePercentages;
        this.additivePercentages=additivePercentages;
        this.trueValue=trueValue;
        this.canNegative=canNegative;
        this.canTrueNegative=canTrueNegative;
    }

    /// <summary>
    /// Adds a flat number to this value
    /// </summary>
    /// <param name="value">The number to add</param>
    public void AddFlatValue(float value)
    {
        this.value += value;
    }

    /// <summary>
    /// Adds an additive percentage to this value
    /// Percentage in floating point numbers (0.1 = 10%)
    /// </summary>
    /// <param name="percentage">The additive percentage</param>
    public void AddAdditivePercentage(float percentage)
    {
        this.additivePercentages += percentage;
    }

    /// <summary>
    /// Adds a multiplicative percentage to this value
    /// Percentage in floating point numbers (0.1 = 10%)
    /// </summary>
    /// <param name="percentage"></param>
    public void AddMultiplicativePercentage(float percentage)
    {
        this.multiplicativePercentages = multiplicativePercentages * (1 + percentage);
    }

    /// <summary>
    /// Adds a true value to this value,
    /// Applied last and unaffected by other modifiers
    /// </summary>
    /// <param name="trueValue"></param>
    public void AddTrueValue(float trueValue)
    {
        this.trueValue += trueValue;
    }

    /// <summary>
    /// Run once, when modifiers are finished being added
    /// Calculates and returns final value
    /// </summary>
    public float Calculate()
    {
        float finalValue;
        // Perform value additive and multiplcative math
        finalValue = ((value * multiplicativePercentages) * additivePercentages);

        // Check negative + bool
        if(finalValue < 0.0f && !canNegative)
            finalValue = 0.0f;

        // Add true value
        finalValue += trueValue;

        // Check True negative + bool
        if (finalValue < 0.0f && !canTrueNegative)
            finalValue = 0.0f;

        // Return the value
        return finalValue;
    }
}
