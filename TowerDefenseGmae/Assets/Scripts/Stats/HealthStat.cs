using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthStat : Stat
{
    public override string ToString()
    {
        return "Max Health: " + base.currentFinalValue;
    }
}
