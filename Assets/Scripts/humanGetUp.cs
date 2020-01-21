using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class humanGetUp : MonoBehaviour {

    private AnimatorStateInfo stateInfo;
    public GameObject gameDirector;
    public int variation = 0;

    public GameObject Image;

    Animator anim;
    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
        anim.SetInteger("variation", variation);
        GameObject.Find("human_back").GetComponent<Animator>().SetInteger("variation", variation);

        Image.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        //続けて更新
        stateInfo = anim.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.normalizedTime >= 0.95f && stateInfo.IsTag("Finish"))
        {
            Image.SetActive(true);
            gameDirector.GetComponent<GameDirector>().SetGameState();
        }

    }
}
