using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Game game;
    [SerializeField] private GameObject ui;
    [SerializeField] private Text title;
    [SerializeField] private Text score;
    void Start()
    {
        if (SceneManager.GetActiveScene().name != "Menu")
        {
            ui.SetActive(false);
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name != "Menu")
        {
            if (game.GetWin())
            {
                game.SetPause();
                title.text = "You win !";
                score.text = "You've done it in " + game.GetTimer() + " congratulations.";
                ui.SetActive(true);
            
            }
            else if (game.GetGameOver())
            {
                game.SetPause();
                title.text = "You lose !";
                score.text = "Try again.";
                ui.SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (game.menuing)
                {
                    ui.SetActive(false);
                    game.UnPause();
                }
                else
                {
                    game.SetPause();
                    title.text = "Pause";
                    ui.SetActive(true);
                }
            }
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void GameMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Leave()
    {
        Application.Quit();
    }
}
