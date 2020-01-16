using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {

    public Animator transitionAnim;
    public GameObject GameClearUI;
    public GameObject GamePauseUI;
    public GameDirector gameDirector;

    public static string NextSceneId { get; private set; }
    public bool gamePaused { get; private set; }

    void Start()
    {
        GamePauseUI.SetActive(false);
        GameClearUI.SetActive(false);
        string CurrentSceneId = SceneManager.GetActiveScene().name;
        int id = 0;
        try
        {
            id = int.Parse(CurrentSceneId.Replace("Scene", ""));
        }
        catch(System.Exception e)
        {
            Debug.Log("Exception source: " + e.Source);
        }

        NextSceneId = "Scene" + (id % 9 + 1);
    }
    
    // Update is called once per frame
    void Update ()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if(gamePaused)
        {
            if(Input.GetButtonDown("Interaction"))
            {
                StartCoroutine(GameReset());
                Resume();
            }
            else if (Input.GetButtonDown("Jump"))
            {
                StartCoroutine(GameRestart());
                Resume();
            }
        }
        else if (gameDirector.gameClear)
        {
            StartCoroutine(GameClear());
        }
	}

    void Pause()
    {
        GamePauseUI.SetActive(true);
        Time.timeScale = 0.0f;
        gamePaused = true;
    }

    void Resume()
    {
        GamePauseUI.SetActive(false);
        Time.timeScale = 1.0f;
        gamePaused = false;
    }

    IEnumerator GameReset()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Title");
    }

    IEnumerator GameRestart()
    {
        string CurrentSceneId = SceneManager.GetActiveScene().name;

        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(CurrentSceneId);
    }

    IEnumerator GameClear()
    {
        transitionAnim.SetTrigger("end");
        GameClearUI.SetActive(true);
        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene("GameClear");
    }
}
