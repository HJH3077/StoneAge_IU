using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSW_FishClass : MonoBehaviour
{
    //����� ������ �̹���UI����
    public int fishCount;
    public string catchedFish;
   

    public LSW_FishClass(string _catchedFish, int _fishCount)
    {
        this.catchedFish = _catchedFish;
        this.fishCount = _fishCount;

    }

   
		
}
