using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSheet : Sheet
{
    public override Vector3[] LevelPositions { get; set; }
    void Start()
    {
        LevelPositions = new Vector3[]
        {
            new Vector3(8f,0.25f,-8f),
            new Vector3(-8f,0.25f,5f),
            new Vector3(-8f,0.25f,-4.5f)
        };
    }
}
