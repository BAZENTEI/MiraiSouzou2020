using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {

    public Animator transitionAnim;
    public GameObject GameClearObject;
    public GameDirector gameDirector;

    public string targetSceneName;

    public static string NextSceneId { get; private set; }

    void Start()
    {
        GameClearObject.SetActive(false);
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
        if (Input.GetButtonDown("Reset"))
        {
            StartCoroutine(GameRestart());
        }
        if(Input.GetButtonDown("Cancel"))
        {
            StartCoroutine(GameReset());
        }
        if (gameDirector.gameClear)
        {
            StartCoroutine(GameClear());
        }
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
        GameClearObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene(targetSceneName);
    }
}
