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
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        if (x != 0)
        {
            StartCoroutine(SwitchSceneRoutine(0, x));
        }
        if(y != 0)
        {
            StartCoroutine(SwitchSceneRoutine(1, y));
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

    IEnumerator SwitchSceneRoutine(int direction, float value)
    {
        if (canSwitch)
        {
            canSwitch = false;
            if(direction == 0)
            {
                if(selectedScene != 0)
                {
                    if (value > 0 && selectedScene % 3 != 0)
                    {
                        selectedScene += 1;
                    }
                    if (value < 0 && (selectedScene - 1) % 3 != 0)
                    {
                        selectedScene -= 1;
                    }
                }
            }
            if(direction == 1)
            {
                if (value > 0)
                {
                    if (selectedScene > 3)
                    {
                        selectedScene -= 3;
                    }
                    else
                    {
                        selectedScene = 0;
                    }
                }
                if (value < 0)
                {
                    if (selectedScene == 0)
                        selectedScene = 2;

                    else if(selectedScene < sceneSelections.Length - 3)
                    selectedScene += 3;
                }
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
