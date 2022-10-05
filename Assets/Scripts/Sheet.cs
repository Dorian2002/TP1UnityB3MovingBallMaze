using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Sheet : MonoBehaviour
{
    public abstract Vector3[] LevelPositions { get; set; }
    public void NextPosition(int level)
    {
        gameObject.transform.localPosition = (Vector3)LevelPositions.GetValue(level-1);
    }
}
