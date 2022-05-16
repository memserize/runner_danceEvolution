using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateValueAssigner : MonoBehaviour
{
    public int index;

    [Space]
    public List<GateValues> gateValues = new List<GateValues>();
}

[System.Serializable]
public class GateValues 
{
    public GateObject.Period period;
    public int value;
}