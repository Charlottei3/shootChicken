using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void level()
    {
        float newSpeed = 20;
        Bird bird = GetComponent<Bird>();
       

        SceneManager.LoadScene("SampleScene");
    }

}
