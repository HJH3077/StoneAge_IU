using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSW_TestLecture : MonoBehaviour
{
    [HideInInspector]
    public int A;
    int B;
    [SerializeField]
    private int C;
    protected int D;

    [SerializeField]
    private Sprite tempObj;

    void Start()
    {
        //tempObj = GameObject.Find("Circle");
        tempObj = Resources.Load<Sprite>("Box");
    }

    
    void Update()
    {
        
    }
}
