using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSW_FishClass : MonoBehaviour
{
    //물고기 마리와 이미지UI띠우기
    public int fishCount;
    public string catchedFish;
   

    public LSW_FishClass(string _catchedFish, int _fishCount)
    {
        this.catchedFish = _catchedFish;
        this.fishCount = _fishCount;

    }

   
		
}
