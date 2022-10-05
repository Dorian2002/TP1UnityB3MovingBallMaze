using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private int lifes;
    private bool gameover;
    private bool win;
    public bool menuing;
    [SerializeField] private Text lifesText;
    [SerializeField] private Text timerText;
    [SerializeField] GameObject ball;
    [SerializeField] private Sheet[] StartEndSheets;
    private GameObject tempBall;
    [SerializeField] private int Level;
    private float min;
    private float sec;
    private void Start()
    {
        min = 0;
        sec = 0;
        gameover = false;
        win = false;
        Level = 1;
        lifes = 2;
        lifesText.text = "Remaining attempt : "+lifes.ToString();
        timerText.text = "00:00";
        UnPause();
        tempBall = Instantiate(ball, this.transform);
    }

    private void Update()
    {
        if (!gameover && !win && !menuing)
        {
            sec += Time.deltaTime;
            if (sec >= 59)
            {
                if (min >= 59)
                {
                    gameover = true;
                }
                else
                {
                    min += 1;
                    sec = 0; 
                }

            }

            timerText.text = "Time : " + string.Format("{0:00}:{1:00}", min, sec);
        }
    }

    public void RespawnBall( bool changeMap)
    {
        if (changeMap)
        {
            tempBall.SetActive(false);
            Destroy(tempBall);
            tempBall = Instantiate(ball, this.transform);
            ChangeBallPos();
        }
        else
        {
            if (!gameover && lifes > 0)
            {
                lifes -= 1;
                lifesText.text = "Remaining attempt : "+lifes.ToString();
                tempBall.SetActive(false);
                Destroy(tempBall);
                tempBall = Instantiate(ball, this.transform);
                ChangeBallPos();
            }
            else
            {
                gameover = true;
                Destroy(tempBall);
            }
        }

    }

    public void ChangeMap()
    {
        Level += 1;
        if (Level > 3)
        {
            win = true;
        }
        else
        {
            foreach (Sheet sheet in StartEndSheets)
            {
                sheet.NextPosition(Level);
            }
            RespawnBall(true);
        }
    }

    private void ChangeBallPos()
    {
        tempBall.transform.position = new Vector3 (StartEndSheets[0].transform.position.x,StartEndSheets[0].transform.position.y+3,StartEndSheets[0].transform.position.z);
    }

    public void SetPause()
    {
        menuing = true;
        Physics.autoSimulation = false;
    }
    
    public void UnPause()
    {
        menuing = false;
        Physics.autoSimulation = true;
    }

    public bool GetWin()
    {
        return win;
    }
    public bool GetGameOver()
    {
        return gameover;
    }

    public string GetTimer()
    {
        return timerText.text.Substring(7);
    }
}
