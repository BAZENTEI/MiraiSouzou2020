using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSelectionController : MonoBehaviour {
    public TitleScreenController titleScreen;
    public Animator transitionAnim;

    private bool canSwitch = true;
    private float coolDownUntilNextSwitch = 0.5f;

    GameObject[] sceneImages;

    int selectedScene;
	// Use this for initialization
	void Start () {
        selectedScene = 1;
        sceneImages = GameObject.FindGameObjectsWithTag("SceneSelectionTag");
	}

    private void FixedUpdate()
    {
        for (int i = 0; i < 9; ++i)
        {
            Animator animator = sceneImages[i].GetComponent<Animator>();
            if (selectedScene - 1 == i)
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

        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(StartLoad());
        }
    }

    IEnumerator SwitchSceneRoutine(int direction, float value)
    {
        if (canSwitch)
        {
            canSwitch = false;
            if(direction == 0)
            {
                if(value > 0 && selectedScene % 3 != 0)
                {
                    selectedScene += 1;
                }
                if (value < 0 && (selectedScene - 1) % 3 != 0)
                {
                    selectedScene -= 1;
                }
            }
            if(direction == 1)
            {
                if (value > 0 && selectedScene > 3)
                {
                    selectedScene -= 3;
                }
                if (value < 0 && selectedScene < 7)
                {
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

    IEnumerator StartLoad()
    {
        string sceneName = "Scene" + selectedScene;
        transitionAnim.SetTrigger("end");
        foreach(GameObject obj in sceneImages)
        {
            Animator anim = obj.GetComponent<Animator>();
            anim.SetTrigger("fadeOut");
        }
        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene(sceneName);
    }
}
