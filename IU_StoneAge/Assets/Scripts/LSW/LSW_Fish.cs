using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSW_Fish
{
    public string name;
    public string spriteID;
    public int baseCost;
    public int spokeWeight;

    public LSW_Fish(string a, string b, int c, int d) {
        name = a;
        spriteID = b;
        baseCost = c;
        spokeWeight = d;
    }
}
