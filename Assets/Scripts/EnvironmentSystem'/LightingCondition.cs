using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct LightingCondition
{
    public Lighting lighting;
    public bool isNaturalLight;

    public LightingCondition(Lighting lighting, bool isNaturalLight)
    {
        this.lighting = lighting;
        this.isNaturalLight = isNaturalLight;
    }
}
