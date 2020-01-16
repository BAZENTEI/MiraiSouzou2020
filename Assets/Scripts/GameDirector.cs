using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{

    public bool gameClear = false;
    public int  gage = 0;

    public bool performance = false;
    bool gameClearWait = false;//演出の終わりからゲームクリアまでの時間カウントを開始

    float delta = 0.0f;
    public float span = 0.5f;//待つ時間

    public GameObject human;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameClearWait)
        {
            delta += Time.deltaTime;
            if(delta > span)
            gameClear = true;
        }

        //if(human.GetComponent<Animator>().)
    }

    public void SetGameState()
    {
        gameClearWait = true;
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
