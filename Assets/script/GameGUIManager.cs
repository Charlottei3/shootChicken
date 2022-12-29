using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameGUIManager : Singleton<GameGUIManager>
{
    public GameObject homeGui;
    public GameObject gameGui;

    public Dialog gameDialog;
    public Dialog pauseDialog;

    public Image fireRateFilled;
    public Text timeText;
    public Text killCoutingText;

    Dialog m_curDialog;

    public Dialog CurDialog { get => m_curDialog; set => m_curDialog = value; }

    public override void Awake()
    {
        MakeSingleton(false);
    }
    public void gameShowGui(bool isShow)
    {
        if (gameGui)
        {
            gameGui.SetActive(isShow);
        }

        if (homeGui)
            homeGui.SetActive(!isShow);
    }

    public void UpdateTimer(string time)
    {
        if (timeText)
            timeText.text = time;
    }

    public void UpdateKiller(int killer)
    {
        if (killCoutingText)
            killCoutingText.text = "x" + killer.ToString();
    }

    public void UpdateFireRate(float rate)
    {
        if (fireRateFilled)
            fireRateFilled.fillAmount = rate;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;

        if (pauseDialog)
        {
            pauseDialog.Show(true);
            pauseDialog.UpdateDialog("GAME PAUSE", "BEST KILL : x" + Pri.bestScore);
            m_curDialog = pauseDialog;
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;

        if (m_curDialog)
        {
            m_curDialog.Show(false);
        }
    }
    public void BackToHome()
    {
        ResumeGame();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void RePlayGame()
    {
        if (m_curDialog)
            m_curDialog.Show(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        managerGame.Ins.PlayGame();
    }

    public void Exit()
    {
        ResumeGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Application.Quit();
    }
}