using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class humanGetUp : MonoBehaviour {

    private AnimatorStateInfo stateInfo;
    public GameObject gameDirector;

    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {

        //続けて更新
        stateInfo = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);

        if (stateInfo.normalizedTime >= 0.95f && stateInfo.IsName("human_getup"))
        {
            gameDirector.GetComponent<GameDirector>().SetGameState();
        }


    }
}
