using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Pri 
{

    
    public static int bestScore
    {
        get => PlayerPrefs.GetInt(GameConst.Best_score, 0);

        set
        {
            int curBestScore = PlayerPrefs.GetInt(GameConst.Best_score, 0);

            if (value > curBestScore)
            
               PlayerPrefs.SetInt(GameConst.Best_score, value);
            
        }
    }
}
