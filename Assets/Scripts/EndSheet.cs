using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSheet : Sheet
{
    public override Vector3[] LevelPositions { get; set; }
    void Start()
    {
        LevelPositions = new Vector3[]
        {
            new Vector3(-8f,0.25f,5f),
            new Vector3(-8f,0.25f,-4.5f),
            new Vector3(1.5f,0.25f,5f)
        };
    }
}
