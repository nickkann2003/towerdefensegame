using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatModifier
{
    public float flatMod;
    public float aPMod;
    public float mPMod;
    public float tMod;

    /// <summary>
    /// Constructor for a stat modifier
    /// </summary>
    /// <param name="f">Flat value mod</param>
    /// <param name="a">Additive percentage value mod</param>
    /// <param name="m">Multiplicative percentage value mod</param>
    /// <param name="t">True value mod</param>
    public StatModifier(float f, float a, float m, float t)
    {
        flatMod = f;
        aPMod = a;
        mPMod = m;
        tMod = t;
    }

    /// <summary>
    /// Modifies the internal variables of a Value object
    /// </summary>
    /// <param name="value">The Value object to be modified</param>
    public void ModifyValue(Value value)
    {
        value.AddFlatValue(flatMod);
        value.AddAdditivePercentage(aPMod);
        value.AddMultiplicativePercentage(mPMod);
        value.AddTrueValue(tMod);
    }

    /// <summary>
    /// Adjusts the mods for this StatModifier
    /// </summary>
    /// <param name="f">Flat value mod</param>
    /// <param name="a">Additive percentage value mod</param>
    /// <param name="m">Multiplicative percentage value mod</param>
    /// <param name="t">True value mod</param>
    public void AdjustMods(float f, float a, float m, float t)
    {
        this.flatMod = f;
        this.aPMod = a;
        this.mPMod = m;
        this.tMod = t;
    }
}
