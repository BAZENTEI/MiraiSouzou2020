using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{

    public bool gameClear = false;
    public int  gage = 0;

    public bool performance = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetGameState()
    {
        gameClear = true;
    }

    public void SetPerformance()
    {
        performance = true;
    }

    public bool SetGage(float percent)
    {
        percent = percent * 100.0f;
        if (percent > 100.0f)
        {
            gage = 100;
            return true;
        }
        else
        {
            gage = (int)percent;
            return true;
        }

    }

}
