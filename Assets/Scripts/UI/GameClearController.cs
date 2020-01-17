using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClearController : MonoBehaviour {

    // Use this for initialization
    string nextScene;

    void Start()
    {
        nextScene = SceneTransition.NextSceneId;
        
        if(nextScene == "Title")
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("NextLevelTag");

            foreach (GameObject obj in gameObjects)
            {
                obj.SetActive(false);
            }
        }
    }
	// Update is called once per frame
	void Update () {
		if(nextScene != "Title" && Input.GetButtonDown("Interaction"))
        {
            StartCoroutine(NextScene());
        }
        else if (Input.GetButtonDown("Cancel"))
        {
            StartCoroutine(BackToTitle());
        }
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene(nextScene);
    }
    IEnumerator BackToTitle()
    {
        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene("Title");
    }
}
