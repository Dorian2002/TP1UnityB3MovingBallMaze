using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] public Game game;

    private void Awake()
    {
        game = GetComponentInParent<Game>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Respawn")
        {
            game.RespawnBall(false);
        }
        else if (col.tag == "Finish")
        {
            game.ChangeMap();
        }
        else if (col.tag == "Fall")
        {
            game.RespawnBall(false);
        }
    }
}
