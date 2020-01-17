using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSelectionController : MonoBehaviour {
    public TitleScreenController titleScreen;
    public GameInfoController gameInfo;
    public Animator transitionAnim;

    private bool canSwitch = true;
    private float coolDownUntilNextSwitch = 0.5f;

    GameObject[] sceneSelections;

    int selectedScene;
	// Use this for initialization
	void Start () {
        selectedScene = 0;
        sceneSelections = GameObject.FindGameObjectsWithTag("SceneSelectionTag");
        UpdateButton();

    }

    void UpdateButton()
    {
        for (int i = 0; i < sceneSelections.Length; ++i)
        {
            Animator animator = sceneSelections[i].GetComponent<Animator>();
            if (selectedScene == i)
            {
                animator.SetBool("active", true);
            }
            else
            {
                animator.SetBool("active", false);
            }
        }
    }
    
    void Update()
    {
        float dir = Input.GetAxis("Vertical");
        if (dir != 0f)
        {
            StartCoroutine(SwitchSceneRoutine(dir));
        }

        if(Input.GetButtonDown("Interaction"))
        {
            StartCoroutine(StartLoadScene());
        }
        if(Input.GetButtonDown("Cancel"))
        {
            StartCoroutine(CallCredits());
        }
        UpdateButton();
    }
    IEnumerator CallCredits()
    {
        yield return new WaitForSeconds(0.05f);

        gameObject.SetActive(false);
        gameInfo.gameObject.SetActive(true);
    }

    IEnumerator SwitchSceneRoutine(float value)
    {
        if (canSwitch)
        {
            canSwitch = false;
            if (value > 0)
            {
                selectedScene = (selectedScene + sceneSelections.Length - 1) % sceneSelections.Length;
            }
            else
            {
                selectedScene = (selectedScene + 1) % sceneSelections.Length;
            }

            yield return new WaitForSeconds(coolDownUntilNextSwitch);
            canSwitch = true;
        }
        else
        {
            yield return new WaitForSeconds(0f);
        }
    }

    IEnumerator StartLoadScene()
    {
        string sceneName = "Scene" + (selectedScene + 1);
        foreach(GameObject obj in sceneSelections)
        {
            Animator anim = obj.GetComponent<Animator>();
            anim.SetTrigger("fadeOut");
        }
        yield return new WaitForSeconds(0);

        SceneManager.LoadScene(sceneName);
    }
}
