using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class human_sindan : MonoBehaviour {

    public GameObject gameDirector;
   
    bool firstTranslation;
    bool stop;
    bool pose;
    // Use this for initialization
    void Start () {

        firstTranslation = false;
        stop = false;
        pose = false;

        
    }
	
	// Update is called once per frame
	void Update () {
        

        if (transform.position.y > -10.5f && firstTranslation == false)
        {
            //gameObject.SetActive(false);
            //下に移動
            transform.Translate(0, -0.5f * Time.deltaTime, 0);

            //all right?
            if(transform.position.y <= -10.5f)
                firstTranslation = true;

        }


        if(gameDirector.GetComponent<GameDirector>().performance == true && stop == false)
        {
            transform.Translate(0, 0.75f * Time.deltaTime, 0);
            if (transform.position.y >= -7.02f)
            {
                stop = true;
                pose = true;
                //gameDirector.GetComponent<GameDirector>().SetGameState();
            }    
                
        }

        //!
       GameObject.Find("human_flame").GetComponent<Animator>().SetBool("pose", pose);
       GameObject.Find("human_back").GetComponent<Animator>().SetBool("pose", pose);
    }
}
