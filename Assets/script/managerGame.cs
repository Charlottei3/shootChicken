using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class managerGame : Singleton<managerGame>
{
    public Bird[] birds;

    public float spawnTime;

    public int timeLimit;
    int cur_timeLimit;

    int m_killBird;


    bool isgameOver;

    public bool IsgameOver { get => isgameOver; set => isgameOver = value; }
    public int KillBird { 
        get => m_killBird;
        set => m_killBird = value;
    }


    public override void Start()
    {
        
        GameGUIManager.Ins.gameShowGui(false);
        GameGUIManager.Ins.UpdateKiller(m_killBird);
        
    }

    public override void Awake()
    {
        MakeSingleton(false);
        cur_timeLimit = timeLimit;
       
    }

    public void SpawnBird()
    {
        Vector3 spawnbird = Vector3.zero;

        float ranCheck = Random.Range(0f, 1f);

        if (ranCheck >= 0.5f)
        {
            spawnbird = new Vector3(10, Random.Range(-1.5f, 3f), 0);
        }
        else
        {
            spawnbird = new Vector3(-10, Random.Range(-1.5f, 3f), 0);
        }

        if (birds != null && birds.Length > 0)
        {
            int ranIn = Random.Range(0, birds.Length);

            if (birds[ranIn] != null)
            {
                Bird bird = Instantiate(birds[ranIn], spawnbird, Quaternion.identity);
            }
        }
      
    }
    IEnumerator GameSpawn()
    {
        while (!isgameOver)
        {
            SpawnBird();
            yield return new WaitForSeconds(spawnTime);
        }
    }

    public void PlayGame()
    {
        StartCoroutine(GameSpawn());
        StartCoroutine(TimeCountDowm());

       GameGUIManager.Ins.gameShowGui(true);
    }
    IEnumerator TimeCountDowm() { 
        while(cur_timeLimit > 0)
        {
            yield return new WaitForSeconds(1f);

            cur_timeLimit--;
           
             
            if(cur_timeLimit <= 0)
            {
                isgameOver = true;

               // GameGUIManager.Ins.gameDialog.UpdateDialog("YOUR BEST" ,"YOUR BEST KILL : x" + m_killBird);
               if(m_killBird > Pri.bestScore)
                {
                    GameGUIManager.Ins.gameDialog.UpdateDialog("NEW BEST", "YOUR BEST KILL : x" + m_killBird);
                }
                else if (m_killBird < Pri.bestScore)
                {
                    GameGUIManager.Ins.gameDialog.UpdateDialog("YOUR BEST", "YOUR BEST KILL : x" + Pri.bestScore);
                }

                Pri.bestScore = m_killBird;

                GameGUIManager.Ins.gameDialog.Show(true);
                GameGUIManager.Ins.CurDialog = GameGUIManager.Ins.gameDialog;
                
            }

            GameGUIManager.Ins.UpdateTimer(IntToTime(cur_timeLimit));

        }
    }

    string IntToTime(int i)
    {
        float minute = Mathf.Floor(i / 60);
        float seconds = Mathf.RoundToInt(i % 60);

        return  minute.ToString("00") + ":" + seconds.ToString("00");
    }
    
}
